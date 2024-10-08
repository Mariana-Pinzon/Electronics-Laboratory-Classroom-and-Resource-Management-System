using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Void : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// <inheritdoc />
            /// Trigger Inventory
            migrationBuilder.Sql(@"
    CREATE OR ALTER TRIGGER trg_inventories
    ON[inventories]

    AFTER INSERT, UPDATE, DELETE
    AS
    BEGIN
        SET NOCOUNT ON;
    --If there are inserted or updated records
        IF EXISTS(SELECT* FROM inserted)
        BEGIN
            INSERT INTO inventories_history(
			Inventory_ID,
			Equipment_ID, 
			Available_quantity, 
			Laboratory_ID, 
			ModifiedDate, 
			ModifiedBy)
            SELECT 
			i.Inventory_ID, 
			i.Equipment_ID, 
            i.Available_quantity,
			i.Laboratory_ID,
                GETDATE(),
                   CASE
                       WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                       ELSE 'INSERT'
                   END
            FROM inserted i;
		END

    -- If there are deleted records
    IF EXISTS(SELECT * FROM deleted)
        BEGIN
            INSERT INTO inventories_history(
			Inventory_ID,
			Equipment_ID,
			Available_quantity,
			Laboratory_ID,
			ModifiedDate, 
			ModifiedBy)
            SELECT  
			d.Inventory_ID, 
			d.Equipment_ID, 
			d.Available_quantity, 
			d.Laboratory_ID, 
             GETDATE(), 
             'DELETE'
                  FROM deleted d;
    END
END;
     ");

            //Trigger Status_Equipment
            migrationBuilder.Sql(@"
    CREATE OR ALTER TRIGGER trg_status_equipments
    ON[status_equipments]

    AFTER INSERT, UPDATE, DELETE
    AS
    BEGIN
        SET NOCOUNT ON;
    --If there are inserted or updated records
        IF EXISTS(SELECT* FROM inserted)
        BEGIN
            INSERT INTO status_equipments_history(
             StatusE_ID,
             Status,
             ModifiedDate,
             ModifiedBy)
            SELECT 
			i.StatusE_ID, 
			i.Status, 
                GETDATE(),
                   CASE
                       WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                       ELSE 'INSERT'
                   END
            FROM inserted i;
		END

    -- If there are deleted records
    IF EXISTS(SELECT * FROM deleted)
        BEGIN
            INSERT INTO status_equipments_history(
             StatusE_ID,
             Status,
             ModifiedDate,
             ModifiedBy)
            SELECT  
			d.StatusE_ID, 
			d.Status, 
             GETDATE(), 
             'DELETE'
                  FROM deleted d;
    END
END;");

            //Trigger Status_Reservation
            migrationBuilder.Sql(@"
    CREATE OR ALTER TRIGGER trg_status_reservations
    ON[status_reservations]

    AFTER INSERT, UPDATE, DELETE
    AS
    BEGIN
        SET NOCOUNT ON;
    --If there are inserted or updated records
        IF EXISTS(SELECT* FROM inserted)
        BEGIN
            INSERT INTO status_reservations_history(
             StatusR_ID,
             StatusR,
             ModifiedDate,
             ModifiedBy)
            SELECT 
			i.StatusR_ID, 
			i.StatusR, 
                GETDATE(),
                   CASE
                       WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                       ELSE 'INSERT'
                   END
            FROM inserted i;
		END

    -- If there are deleted records
    IF EXISTS(SELECT * FROM deleted)
        BEGIN
            INSERT INTO status_reservations_history(
             StatusR_ID,
             StatusR,
             ModifiedDate,
             ModifiedBy)
            SELECT  
			d.StatusR_ID, 
			d.StatusR, 
             GETDATE(), 
             'DELETE'
                  FROM deleted d;
    END
END;");

            //Trigger User
            migrationBuilder.Sql(@"
    CREATE OR ALTER TRIGGER trg_users
    ON[users]

    AFTER INSERT, UPDATE, DELETE
    AS
    BEGIN
        SET NOCOUNT ON;
    --If there are inserted or updated records
        IF EXISTS(SELECT* FROM inserted)
        BEGIN
            INSERT INTO users_history(
			User_ID,
			First_Name, 
			Last_Name, 
			Email, 
			Password,
            User_Type_ID,
			ModifiedDate, 
			ModifiedBy)
            SELECT 
			i.User_ID, 
			i.First_Name, 
			i.Last_Name, 
			i.Email, 
			i.Password,
            i.User_Type_ID,
                GETDATE(),
                   CASE
                       WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                       ELSE 'INSERT'
                   END
            FROM inserted i;
		END

    -- If there are deleted records
    IF EXISTS(SELECT * FROM deleted)
        BEGIN
            INSERT INTO users_history(
			User_ID,
			First_Name, 
			Last_Name, 
			Email, 
			Password,
            User_Type_ID,
			ModifiedDate, 
			ModifiedBy)
            SELECT 
			d.User_ID, 
			d.First_Name, 
			d.Last_Name, 
			d.Email, 
			d.Password,
            d.User_Type_ID,
             GETDATE(), 
             'DELETE'
                  FROM deleted d;
    END
END;");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_inventories;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_status_equipments;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_status_reservations;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_users;");
        }
    }
}