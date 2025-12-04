CREATE OR REPLACE PROCEDURE sp_create_user(
    IN p_name TEXT,
    IN p_phone TEXT,
    IN p_city_id INT,
    IN p_street TEXT,
    OUT p_user_id INT,
    OUT p_address_id INT
)
LANGUAGE plpgsql
AS $$
BEGIN
    BEGIN
        INSERT INTO "Users" ("Name", "Phone")
        VALUES (p_name, p_phone)
        RETURNING "Id" INTO p_user_id;

        INSERT INTO "Addresses" ("UserId", "CityId", "Street")
        VALUES (p_user_id, p_city_id, p_street)
        RETURNING "Id" INTO p_address_id;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE;
    END;
END;
$$;
