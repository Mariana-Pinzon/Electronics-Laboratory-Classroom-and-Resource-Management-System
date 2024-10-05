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
     CREATE OR ALTER TRIGGER trg_Inventory
     ON[inventories]

     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
     --If there are inserted or updated records
         IF EXISTS(SELECT* FROM inserted)
         BEGIN
             INSERT INTO Inventory_History(Inventory_History_ID,Inventory_ID,Equipment_ID,Available_quantity,Total_quantity,Last_update,Laboratory_ID,Date,ModifiedDate, ModifiedBy)
             SELECT i.Id, i.Inventory.ID, i.Equipment.ID, i.Available_quantity, i.Total_quantity, i.Last_update, i.Laboratory_ID, i.Date,
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
             INSERT INTO Inventory_History(Inventory_History_ID,Inventory_ID,Equipment_ID,Available_quantity,Total_quantity,Last_update,Laboratory_ID,Date,ModifiedDate, ModifiedBy)
             SELECT  d.Id, d.Inventory.ID, d.Equipment.ID, d.Available_quantity, d.Total_quantity, d.Last_update, d.Laboratory_ID, d.Date,, GETDATE(), 'DELETE'
                   FROM deleted d;
     END
 END;
     ");

            //Trigger Status_Equipment
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_Status_Equipment
     ON [status_equipments]

     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
         -- If there are inserted or updated records
         IF EXISTS (SELECT * FROM inserted)
         BEGIN
             INSERT INTO Status_Equipment_History (Status_Equipment_History_ID,StatusE_ID, Status, Date, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.StatusE_ID, i.Status, i. Date, i.ModifiedDate, i. ModifiedBy,
                 GETDATE(),
                    CASE 
                        WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                        ELSE 'INSERT' 
                    END
             FROM inserted i;
         END
 
         -- If there are deleted records
         IF EXISTS (SELECT * FROM deleted)
         BEGIN
             INSERT INTO Status_Equipment_History (Status_Equipment_History_ID,StatusE_ID, Status, Date, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.StatusE_ID, d.Status, d.Date, d.ModifiedDate, d.ModifiedBy GETDATE(), 'DELETE'
                   FROM deleted d;
         END
     END;");

            //Trigger Status_Reservation
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_Status_Reservation
     ON [status_reservations]

     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
         -- If there are inserted or updated records
         IF EXISTS (SELECT * FROM inserted)
         BEGIN
             INSERT INTO Status_Reservation_History (Status_Reservation_History_ID,StatusR_ID, StatusR, Date, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.StatusR_ID, i.StatusR, i. Date, i.ModifiedDate, i. ModifiedBy,
                 GETDATE(),
                    CASE 
                        WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                        ELSE 'INSERT' 
                    END
             FROM inserted i;
         END
 
         -- If there are deleted records
         IF EXISTS (SELECT * FROM deleted)
         BEGIN
             INSERT INTO Status_Reservation_History (Status_Reservation_History_ID,StatusR_ID, StatusR, Date, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.StatusR_ID, d.StatusR, d.Date, d.ModifiedDate, d.ModifiedBy GETDATE(), 'DELETE'
                   FROM deleted d;
         END
     END;");

            //Trigger User
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_User
     ON [users]

     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
         -- If there are inserted or updated records
         IF EXISTS (SELECT * FROM inserted)
         BEGIN
             INSERT INTO User_History (User_History_ID,User_ID, First_Name, Last_Name, Email, Password, User_Type_ID, Date, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.User_ID, i.First_Name, i.Last_Name, i.Email, i. Password, i.User_Type_ID,  i. Date, i.ModifiedDate, i.ModifiedBy,
                 GETDATE(),
                    CASE 
                        WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                        ELSE 'INSERT' 
                    END
             FROM inserted i;
         END
 
         -- If there are deleted records
         IF EXISTS (SELECT * FROM deleted)
         BEGIN
             INSERT INTO User_History (User_History_ID,User_ID, First_Name, Last_Name, Email, Password, User_Type_ID, Date, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.User_ID, d.First_Name, d.Last_Name, d.Email, d.Password, d.User_Type_ID, d.Date, d.ModifiedDate, d.ModifiedBy GETDATE(), 'DELETE'
                   FROM deleted d;
         END
     END;");


        }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
