using System;
using System.Data;
using System.Linq;

namespace nothinbutdotnetstore
{
    public interface ICalculate
    {
        int add(int first, int second);
    }

    public class Calculator : ICalculate
    {
        IDbConnection connection;
        IDbCommand command;

        public Calculator(IDbConnection connection, IDbCommand command)
        {
            this.connection = connection;
            this.command = command;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);
            execute_stored_procedure();
            connection.Open();

            return first + second;
        }

        void execute_stored_procedure()
        {
            using(command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            
        }

        void ensure_all_are_positive(params int[] args)
        {
            if(args.All(x => x > 0)) return;
            throw new ArgumentException();
        }

      
    }
}