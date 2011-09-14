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

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);
            ensure_connection_is_open();
            connection.Open();

            return first + second;
        }

        void ensure_connection_is_open()
        {
            if(connection.State == ConnectionState.Closed)
                connection.Open();
        }

        void ensure_all_are_positive(params int[] args)
        {
            if(args.All(x => x > 0)) return;
            throw new ArgumentException();
        }

      
    }
}