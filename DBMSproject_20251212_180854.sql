--
-- PostgreSQL database dump
--

-- Dumped from database version 17.7
-- Dumped by pg_dump version 17.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: calculate_pilot_bonus(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.calculate_pilot_bonus(p_employee_id integer) RETURNS numeric
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_base_salary NUMERIC(10, 2);
    v_flight_hours INT;
    v_bonus_rate REAL := 0.05; -- Varsayılan %5
    v_bonus_amount NUMERIC(10, 2);
BEGIN
    SELECT
        E.Base_Salary, P.FlightHours
    INTO
        v_base_salary, v_flight_hours
    FROM
        Employee E
    JOIN
        Pilot P ON E.Employee_ID = P.Employee_ID
    WHERE
        E.Employee_ID = p_employee_id;

    IF v_base_salary IS NULL THEN
        RETURN 0.00;
    END IF;


    IF v_flight_hours >= 5000 THEN
        v_bonus_rate := 0.15; -- %15
    ELSIF v_flight_hours >= 2000 THEN
        v_bonus_rate := 0.10; -- %10
    ELSE
        v_bonus_rate := 0.05; -- %5
    END IF;

 
    v_bonus_amount := v_base_salary * v_bonus_rate;

    RETURN v_bonus_amount;
END;
$$;


ALTER FUNCTION public.calculate_pilot_bonus(p_employee_id integer) OWNER TO postgres;

--
-- Name: get_available_seats(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_available_seats(p_flight_id integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_max_capacity INT;
    v_booked_seats INT;
    v_available_seats INT;
BEGIN
    SELECT
        AM.Capacity
    INTO
        v_max_capacity
    FROM
        Flight F
    JOIN
        Aircraft A ON F.Tail_Number = A.Tail_Number
    JOIN
        Aircraft_Model AM ON A.Model_ID = AM.Model_ID
    WHERE
        F.Flight_ID = p_flight_id;

    SELECT
        COUNT(*)
    INTO
        v_booked_seats
    FROM
        Booking
    WHERE
        Flight_ID = p_flight_id;

    v_available_seats := v_max_capacity - v_booked_seats;

    RETURN v_available_seats;
END;
$$;


ALTER FUNCTION public.get_available_seats(p_flight_id integer) OWNER TO postgres;

--
-- Name: list_underpaid_employees(numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.list_underpaid_employees(p_salary_threshold numeric) RETURNS TABLE(employee_id integer, employee_name character varying, base_salary numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        E.Employee_ID,
        E.Name,
        E.Base_Salary
    FROM
        Employee E
    WHERE
        E.Base_Salary < p_salary_threshold
    ORDER BY
        E.Base_Salary DESC;
END;
$$;


ALTER FUNCTION public.list_underpaid_employees(p_salary_threshold numeric) OWNER TO postgres;

--
-- Name: search_routes_by_airport(character); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.search_routes_by_airport(p_iata_code character) RETURNS TABLE(route_no integer, origin_iata character, destination_iata character, flight_duration interval)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        R.Route_ID,
        R.Origin_Airport,
        R.Destination_Airport,
        R.Duration
    FROM
        Route R
    WHERE
        R.Origin_Airport = UPPER(p_iata_code) OR R.Destination_Airport = UPPER(p_iata_code);
END;
$$;


ALTER FUNCTION public.search_routes_by_airport(p_iata_code character) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: aircraft; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.aircraft (
    tail_number character varying(20) NOT NULL,
    model_id character varying(50) NOT NULL
);


ALTER TABLE public.aircraft OWNER TO postgres;

--
-- Name: aircraft_model; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.aircraft_model (
    model_id character varying(50) NOT NULL,
    capacity integer NOT NULL,
    range integer NOT NULL,
    CONSTRAINT aircraft_model_capacity_check CHECK ((capacity > 0)),
    CONSTRAINT aircraft_model_range_check CHECK ((range > 0))
);


ALTER TABLE public.aircraft_model OWNER TO postgres;

--
-- Name: airport; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.airport (
    iata character(3) NOT NULL,
    city character varying(100) NOT NULL
);


ALTER TABLE public.airport OWNER TO postgres;

--
-- Name: booking; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.booking (
    passport_number character varying(20) NOT NULL,
    flight_id integer NOT NULL,
    travel_class character varying(50) NOT NULL
);


ALTER TABLE public.booking OWNER TO postgres;

--
-- Name: cabin_crew; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cabin_crew (
    employee_id integer NOT NULL,
    rank character varying(50) NOT NULL
);


ALTER TABLE public.cabin_crew OWNER TO postgres;

--
-- Name: employee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employee (
    employee_id integer NOT NULL,
    name character varying(100) NOT NULL,
    hire_date date NOT NULL,
    base_salary numeric(10,2),
    employee_type character varying(20) NOT NULL,
    CONSTRAINT employee_base_salary_check CHECK ((base_salary >= (0)::numeric))
);


ALTER TABLE public.employee OWNER TO postgres;

--
-- Name: employee_employee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employee_employee_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.employee_employee_id_seq OWNER TO postgres;

--
-- Name: employee_employee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employee_employee_id_seq OWNED BY public.employee.employee_id;


--
-- Name: flight; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.flight (
    flight_id integer NOT NULL,
    tail_number character varying(20) NOT NULL,
    route_id integer NOT NULL,
    date date NOT NULL
);


ALTER TABLE public.flight OWNER TO postgres;

--
-- Name: flight_crew; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.flight_crew (
    employee_id integer NOT NULL,
    flight_id integer NOT NULL,
    role character varying(50) NOT NULL
);


ALTER TABLE public.flight_crew OWNER TO postgres;

--
-- Name: flight_flight_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.flight_flight_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.flight_flight_id_seq OWNER TO postgres;

--
-- Name: flight_flight_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.flight_flight_id_seq OWNED BY public.flight.flight_id;


--
-- Name: passenger; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.passenger (
    passport_number character varying(20) NOT NULL,
    full_name character varying(150) NOT NULL,
    contact_info character varying(255)
);


ALTER TABLE public.passenger OWNER TO postgres;

--
-- Name: pilot; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.pilot (
    employee_id integer NOT NULL,
    licensetype character varying(50) NOT NULL,
    flighthours integer DEFAULT 0,
    CONSTRAINT pilot_flighthours_check CHECK ((flighthours >= 0))
);


ALTER TABLE public.pilot OWNER TO postgres;

--
-- Name: route; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.route (
    route_id integer NOT NULL,
    origin_airport character(3) NOT NULL,
    destination_airport character(3) NOT NULL,
    duration interval NOT NULL,
    CONSTRAINT route_check CHECK ((origin_airport <> destination_airport))
);


ALTER TABLE public.route OWNER TO postgres;

--
-- Name: route_route_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.route_route_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.route_route_id_seq OWNER TO postgres;

--
-- Name: route_route_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.route_route_id_seq OWNED BY public.route.route_id;


--
-- Name: employee employee_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee ALTER COLUMN employee_id SET DEFAULT nextval('public.employee_employee_id_seq'::regclass);


--
-- Name: flight flight_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight ALTER COLUMN flight_id SET DEFAULT nextval('public.flight_flight_id_seq'::regclass);


--
-- Name: route route_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.route ALTER COLUMN route_id SET DEFAULT nextval('public.route_route_id_seq'::regclass);


--
-- Data for Name: aircraft; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: aircraft_model; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.aircraft_model VALUES
	('B737', 180, 5000),
	('A350', 350, 15000),
	('E190', 100, 2500);


--
-- Data for Name: airport; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: booking; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: cabin_crew; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: employee; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: flight; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: flight_crew; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: passenger; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: pilot; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: route; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Name: employee_employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employee_employee_id_seq', 1, false);


--
-- Name: flight_flight_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.flight_flight_id_seq', 1, false);


--
-- Name: route_route_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.route_route_id_seq', 1, false);


--
-- Name: aircraft_model aircraft_model_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.aircraft_model
    ADD CONSTRAINT aircraft_model_pkey PRIMARY KEY (model_id);


--
-- Name: aircraft aircraft_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.aircraft
    ADD CONSTRAINT aircraft_pkey PRIMARY KEY (tail_number);


--
-- Name: airport airport_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.airport
    ADD CONSTRAINT airport_pkey PRIMARY KEY (iata);


--
-- Name: booking booking_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_pkey PRIMARY KEY (passport_number, flight_id);


--
-- Name: cabin_crew cabin_crew_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cabin_crew
    ADD CONSTRAINT cabin_crew_pkey PRIMARY KEY (employee_id);


--
-- Name: employee employee_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (employee_id);


--
-- Name: flight_crew flight_crew_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight_crew
    ADD CONSTRAINT flight_crew_pkey PRIMARY KEY (employee_id, flight_id);


--
-- Name: flight flight_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_pkey PRIMARY KEY (flight_id);


--
-- Name: flight flight_tail_number_route_id_date_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_tail_number_route_id_date_key UNIQUE (tail_number, route_id, date);


--
-- Name: passenger passenger_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.passenger
    ADD CONSTRAINT passenger_pkey PRIMARY KEY (passport_number);


--
-- Name: pilot pilot_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pilot
    ADD CONSTRAINT pilot_pkey PRIMARY KEY (employee_id);


--
-- Name: route route_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.route
    ADD CONSTRAINT route_pkey PRIMARY KEY (route_id);


--
-- Name: aircraft aircraft_model_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.aircraft
    ADD CONSTRAINT aircraft_model_id_fkey FOREIGN KEY (model_id) REFERENCES public.aircraft_model(model_id);


--
-- Name: booking booking_flight_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_flight_id_fkey FOREIGN KEY (flight_id) REFERENCES public.flight(flight_id);


--
-- Name: booking booking_passport_number_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_passport_number_fkey FOREIGN KEY (passport_number) REFERENCES public.passenger(passport_number);


--
-- Name: cabin_crew cabin_crew_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cabin_crew
    ADD CONSTRAINT cabin_crew_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employee(employee_id);


--
-- Name: flight_crew flight_crew_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight_crew
    ADD CONSTRAINT flight_crew_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employee(employee_id);


--
-- Name: flight_crew flight_crew_flight_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight_crew
    ADD CONSTRAINT flight_crew_flight_id_fkey FOREIGN KEY (flight_id) REFERENCES public.flight(flight_id);


--
-- Name: flight flight_route_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_route_id_fkey FOREIGN KEY (route_id) REFERENCES public.route(route_id);


--
-- Name: flight flight_tail_number_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_tail_number_fkey FOREIGN KEY (tail_number) REFERENCES public.aircraft(tail_number);


--
-- Name: pilot pilot_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pilot
    ADD CONSTRAINT pilot_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public.employee(employee_id);


--
-- Name: route route_destination_airport_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.route
    ADD CONSTRAINT route_destination_airport_fkey FOREIGN KEY (destination_airport) REFERENCES public.airport(iata);


--
-- Name: route route_origin_airport_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.route
    ADD CONSTRAINT route_origin_airport_fkey FOREIGN KEY (origin_airport) REFERENCES public.airport(iata);


--
-- PostgreSQL database dump complete
--

--Triggers

--Overbooking 
CREATE OR REPLACE FUNCTION check_flight_capacity()
RETURNS TRIGGER AS $$
DECLARE
    v_available INT;
BEGIN
    v_available := get_available_seats(NEW.Flight_ID);
    
    IF v_available <= 0 THEN
        RAISE EXCEPTION 'Uçuş kapasitesi dolu! Bilet satılamaz. Flight ID: %', NEW.Flight_ID;
    END IF;
    
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_check_capacity
BEFORE INSERT ON Booking
FOR EACH ROW
EXECUTE FUNCTION check_flight_capacity();

--Salary
CREATE TABLE IF NOT EXISTS Salary_Log (
    Log_ID SERIAL PRIMARY KEY,
    Employee_ID INT,
    Old_Salary NUMERIC(10,2),
    New_Salary NUMERIC(10,2),
    Change_Date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE OR REPLACE FUNCTION log_salary_changes()
RETURNS TRIGGER AS $$
BEGIN
    IF OLD.Base_Salary <> NEW.Base_Salary THEN
        INSERT INTO Salary_Log (Employee_ID, Old_Salary, New_Salary)
        VALUES (OLD.Employee_ID, OLD.Base_Salary, NEW.Base_Salary);
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_audit_salary
AFTER UPDATE ON Employee
FOR EACH ROW
EXECUTE FUNCTION log_salary_changes();

---Upper CASE NAME
CREATE OR REPLACE FUNCTION upper_passenger_name()
RETURNS TRIGGER AS $$
BEGIN
    NEW.Full_Name := UPPER(NEW.Full_Name);
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_format_passenger_name
BEFORE INSERT ON Passenger
FOR EACH ROW
EXECUTE FUNCTION upper_passenger_name();

-- PREVENT DELETİON FLİGHT
CREATE OR REPLACE FUNCTION prevent_flight_delete()
RETURNS TRIGGER AS $$
DECLARE
    v_booking_count INT;
BEGIN
    SELECT COUNT(*) INTO v_booking_count 
    FROM Booking 
    WHERE Flight_ID = OLD.Flight_ID;
    
    IF v_booking_count > 0 THEN
        RAISE EXCEPTION 'Bu uçuşa ait biletler var, uçuş silinemez! Önce biletleri iptal edin.';
    END IF;
    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_prevent_flight_deletion
BEFORE DELETE ON Flight
FOR EACH ROW
EXECUTE FUNCTION prevent_flight_delete();

--Insert Operations

INSERT INTO public.passenger (passport_number, full_name, contact_info)
VALUES
    ('US98273611', 'John Anderson', 'john.anderson@example.com'),
    ('TR11223344', 'Zeynep Demir', '+90 555 123 4567'),
    ('DE44556677', 'Klaus Müller', 'k.muller@berlinmail.de'),
    ('JP99887766', 'Sakura Tanaka', 'sakura.t@tokyo.net'),
    ('UK22334455', 'Sarah O''Connor', '+44 20 7946 0123'),
    ('FR77665544', 'Jean-Luc Picard', 'captain@starfleet.org'),
    ('TR55991122', 'Mehmet Öztürk', 'mehmet.ozturk@kurumsal.com.tr'),
    ('CA33221100', 'Emily Blunt', '+1 416 555 0199'),
    ('BR88552211', 'Carlos Silva', 'carlos.silva@rio.br'),
    ('IT66442288', 'Giulia Rossi', '+39 06 698 12345');
	

