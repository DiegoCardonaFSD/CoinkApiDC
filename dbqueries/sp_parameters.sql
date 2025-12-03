CREATE OR REPLACE FUNCTION fn_get_countries()
RETURNS TABLE(
    Id INT,
    Name TEXT,
    Code TEXT
)
AS $$
BEGIN
    RETURN QUERY
    SELECT "Id"::INT, "Name"::TEXT, "Code"::TEXT
    FROM "Countries";
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION fn_get_departments(p_country_id INT DEFAULT NULL)
RETURNS TABLE(
    Id INT,
    Name TEXT,
    CountryId INT
)
AS $$
BEGIN
    RETURN QUERY
    SELECT "Id"::INT, "Name"::TEXT, "CountryId"::INT
    FROM "Departments"
    WHERE p_country_id IS NULL OR "CountryId" = p_country_id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION fn_get_cities(p_department_id INT DEFAULT NULL)
RETURNS TABLE(
    Id INT,
    Name TEXT,
    DepartmentId INT
)
AS $$
BEGIN
    RETURN QUERY
    SELECT "Id"::INT, "Name"::TEXT, "DepartmentId"::INT
    FROM "Cities"
    WHERE p_department_id IS NULL OR "DepartmentId" = p_department_id;
END;
$$ LANGUAGE plpgsql;
