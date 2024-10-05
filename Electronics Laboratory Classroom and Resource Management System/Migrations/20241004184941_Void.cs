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
     CREATE OR ALTER TRIGGER trg_AuditStudent
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
     CREATE OR ALTER TRIGGER trg_AuditAttendant
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
        }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
