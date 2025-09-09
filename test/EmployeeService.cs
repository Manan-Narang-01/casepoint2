using test;
using Npgsql;
using System.Collections.Generic;

public class EmployeeService
{
    private string connectionstring = "Server=localhost;Port=5432;Database=intern093;User Id=postgres;Password=root";

    public void AddEmployee(Employee emp)
    {
        using var conn = new NpgsqlConnection(connectionstring);
        conn.Open();
        using var command = new NpgsqlCommand("INSERT INTO t1(c_id,c_name,c_balance) VALUES(@id,@name,@balance)", conn);
        command.Parameters.AddWithValue("id", emp.EmpId);
        command.Parameters.AddWithValue("name", emp.EmpName);
        command.Parameters.AddWithValue("balance", emp.EmpSalary);
        command.ExecuteNonQuery();
    }

    public List<Employee> GetAllEmployee()
    {
        var list = new List<Employee>();
        using var conn = new NpgsqlConnection(connectionstring);
        conn.Open();
        using var command = new NpgsqlCommand("SELECT * FROM t1", conn);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Employee
            {
                EmpId = reader.GetInt32(0),
                EmpName = reader.GetString(1),
                EmpSalary = reader.GetInt32(2)
            });
        }
        return list;
    }

    public Employee GetEmployee(int id)
    {
        using var conn = new NpgsqlConnection(connectionstring);
        conn.Open();
        using var command = new NpgsqlCommand("SELECT * FROM t1 WHERE c_id=@id", conn);
        command.Parameters.AddWithValue("id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Employee
            {
                EmpId = reader.GetInt32(0),
                EmpName = reader.GetString(1),
                EmpSalary = reader.GetInt32(2)
            };
        }
        return null;
    }

    public bool UpdateEmployee(Employee emp)
    {
        using var conn = new NpgsqlConnection(connectionstring);
        conn.Open();
        using var command = new NpgsqlCommand("UPDATE t1 SET c_name=@name, c_balance=@balance WHERE c_id=@id", conn);
        command.Parameters.AddWithValue("id", emp.EmpId);
        command.Parameters.AddWithValue("name", emp.EmpName);
        command.Parameters.AddWithValue("balance", emp.EmpSalary);
        int rowaffected = command.ExecuteNonQuery();
        return rowaffected > 0;
    }

    public bool DeleteEmployee(int id)
    {
        using var conn = new NpgsqlConnection(connectionstring);
        conn.Open();
        using var command = new NpgsqlCommand("DELETE FROM t1 WHERE c_id=@id", conn);
        command.Parameters.AddWithValue("id", id);
        int rowaffected = command.ExecuteNonQuery();
        return rowaffected > 0;
    }
}
