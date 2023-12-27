using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datatable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DataTable EmployeesDataTable = new DataTable();
            //EmployeesDataTable.Columns.Add("ID", typeof(int));
            //EmployeesDataTable.Columns.Add("Name", typeof(string));
            //EmployeesDataTable.Columns.Add("Country", typeof(string));
            //EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            //EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            //EmployeesDataTable.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            //EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA", 525.5, DateTime.Now);
            //EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            //EmployeesDataTable.Rows.Add(4, "Fadi Jameel", "Egypt", 800, DateTime.Now);
            //EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            //int EmployeesCount = 0;
            //double TotalSalaries = 0;
            //double AverageSalaries = 0;
            //double MinSalaries = 0;
            //double MaxSalaries = 0;

            ////get all employees
            //EmployeesCount = EmployeesDataTable.Rows.Count;
            //TotalSalaries = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", String.Empty));
            //AverageSalaries = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", String.Empty));
            //MinSalaries = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", String.Empty));
            //MaxSalaries = Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", String.Empty));
            ////
            //DataColumn[] PrimaryKey = new DataColumn[1];
            //PrimaryKey[0] = EmployeesDataTable.Columns["ID"];
            //EmployeesDataTable.PrimaryKey = PrimaryKey;


            //Console.WriteLine("\nEmployees List\n");

            //foreach (DataRow row in EmployeesDataTable.Rows)
            //{
            //    Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
            //        row[0], row[1], row[2], row[3], row[4]);
            //}

            //Console.WriteLine();
            //EmployeesDataTable.Clear();
            //EmployeesDataTable.AcceptChanges();
            //foreach (DataRow row in EmployeesDataTable.Rows)
            //{
            //    Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
            //        row[0], row[1], row[2], row[3], row[4]);
            //}


            //Console.ReadKey();
            //DataTable EmployeesDataTable = new DataTable();
            //DataColumn dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(int);
            //dtColumn.ColumnName = "ID";
            //dtColumn.AutoIncrement = true;
            //dtColumn.AutoIncrementSeed = 1;
            //dtColumn.AutoIncrementStep = 1;
            //dtColumn.Caption = "Employee ID";
            //dtColumn.ReadOnly = true;
            //dtColumn.Unique = true;

            //EmployeesDataTable.Columns.Add(dtColumn);
            ///////////////////////////////////////////////
            //dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(string);
            //dtColumn.ColumnName = "Name";
            //dtColumn.AutoIncrement = false;
            //dtColumn.Caption = "Name";
            //dtColumn.ReadOnly = false;
            //dtColumn.Unique = false;

            //EmployeesDataTable.Columns.Add(dtColumn);
            ///////////////////////////////////////////////
            //dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(string);
            //dtColumn.ColumnName = "Country";
            //dtColumn.AutoIncrement = false;
            //dtColumn.Caption = "Country";
            //dtColumn.ReadOnly = false;
            //dtColumn.Unique = false;

            //EmployeesDataTable.Columns.Add(dtColumn);
            ///////////////////////////////////////////////
            //dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(double);
            //dtColumn.ColumnName = "Salary";
            //dtColumn.AutoIncrement = false;
            //dtColumn.Caption = "Salary";
            //dtColumn.ReadOnly = false;
            //dtColumn.Unique = false;

            //EmployeesDataTable.Columns.Add(dtColumn);
            ///////////////////////////////////////////////
            //dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(DateTime);
            //dtColumn.ColumnName = "Date";
            //dtColumn.AutoIncrement = false;
            //dtColumn.Caption = "Date";
            //dtColumn.ReadOnly = false;
            //dtColumn.Unique = false;

            //EmployeesDataTable.Columns.Add(dtColumn);

            //DataColumn[] PrimaryKey = new DataColumn[1];
            //PrimaryKey[0] = EmployeesDataTable.Columns["ID"];
            //EmployeesDataTable.PrimaryKey = PrimaryKey;
            ////////////////////////////////////////////////////////
            //EmployeesDataTable.Rows.Add(null, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            //EmployeesDataTable.Rows.Add(null, "Ali Maher", "KSA", 525.5, DateTime.Now);
            //EmployeesDataTable.Rows.Add(null, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            //EmployeesDataTable.Rows.Add(null, "Fadi Jameel", "Egypt", 800, DateTime.Now);
            //EmployeesDataTable.Rows.Add(null, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            //Console.WriteLine("\nEmployees List\n");

            //foreach (DataRow row in EmployeesDataTable.Rows)
            //{
            //    Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
            //        row[0], row[1], row[2], row[3], row[4]);
            //}





            //Console.ReadKey();


            //DataView EmployeesDataView1 = EmployeesDataTable.DefaultView;
            //EmployeesDataView1.RowFilter = "Country='Jordan' or Country ='Egypt' ";
            //EmployeesDataView1.Sort = "Name ASC ";
            //Console.WriteLine();
            //for (int i = 0; i < EmployeesDataView1.Count; i++)
            //{
            //    Console.WriteLine("{0},{1},{2},{3},{4}",
            //           EmployeesDataView1[i][0], EmployeesDataView1[i][1],
            //           EmployeesDataView1[i][2], EmployeesDataView1[i][3], EmployeesDataView1[i][4]);
            //}

            DataTable EmployeesDataTable = new DataTable("EmployeesDataTable");
            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            EmployeesDataTable.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA", 525.5, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Fadi Jameel", "Egypt", 800, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            Console.WriteLine("\nEmployees List\n");

            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
                    row[0], row[1], row[2], row[3], row[4]);
            }

            DataTable DepaertmentDataTable = new DataTable("DepaertmentDataTable");
            DepaertmentDataTable.Columns.Add("ID", typeof(int));
            DepaertmentDataTable.Columns.Add("Name", typeof(string));

            DepaertmentDataTable.Rows.Add(1, "Mrketing");
            DepaertmentDataTable.Rows.Add(2, "IT");
            DepaertmentDataTable.Rows.Add(3, "HR");

            Console.WriteLine("\nDepartment List\n");
            foreach (DataRow row in DepaertmentDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Department: {1}",
                    row[0], row[1]);
            }
            //////////////////////////////////////////////////
            DataSet dataSet1 = new DataSet();
            dataSet1.Tables.Add(EmployeesDataTable);
            dataSet1.Tables.Add(DepaertmentDataTable);

            Console.WriteLine("\nEmployees List FROM DATA SET\n");

            foreach (DataRow row in dataSet1.Tables["EmployeesDataTable"].Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
                    row[0], row[1], row[2], row[3], row[4]);
            }

            Console.WriteLine("\nDepartment List FROM DATA SET\n");
            foreach (DataRow row in dataSet1.Tables["DepaertmentDataTable"].Rows)
            {
                Console.WriteLine("ID: {0}\t Department: {1}",
                    row[0], row[1]);
            }
            Console.ReadKey();

        }



    }
}
