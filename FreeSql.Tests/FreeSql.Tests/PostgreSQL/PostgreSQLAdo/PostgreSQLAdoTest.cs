﻿using FreeSql.DataAnnotations;
using Npgsql;
using System;
using Xunit;

namespace FreeSql.Tests.PostgreSQL
{
    public class PostgreSQLAdoTest
    {
        [Fact]
        public void Pool()
        {
            var t1 = g.pgsql.Ado.MasterPool.StatisticsFullily;

            var connectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=123456;Database=tedb;ArrayNullabilityMode=Always;Pooling=true;Maximum Pool Size=21";
            using (var t2 = new FreeSqlBuilder()
                .UseConnectionFactory(FreeSql.DataType.PostgreSQL, () => new NpgsqlConnection(connectionString))
                .Build())
            {
                Assert.Equal(connectionString, t2.Ado.ConnectionString);
            }
        }

        [Fact]
        public void SlavePools()
        {
            var t2 = g.pgsql.Ado.SlavePools.Count;
        }

        [Fact]
        public void ExecuteTest()
        {
            Assert.True(g.pgsql.Ado.ExecuteConnectTest());
        }
        [Fact]
        public void ExecuteReader()
        {

        }
        [Fact]
        public void ExecuteArray()
        {

        }
        [Fact]
        public void ExecuteNonQuery()
        {

        }
        [Fact]
        public void ExecuteScalar()
        {

        }

        [Fact]
        public void Query()
        {

            g.pgsql.CodeFirst.SyncStructure<xxx>();
            var t3 = g.pgsql.Ado.Query<xxx>("select * from xxx");

            var t4 = g.pgsql.Ado.Query<(int, string, string)>("select * from xxx");

            var t5 = g.pgsql.Ado.Query<dynamic>("select * from xxx");

            var t6 = g.pgsql.Ado.Query<xxx>("select * from xxx where id in @ids", new { ids = new[] { "1", "2", "3" } });
        }

        [Fact]
        public void QueryMultipline()
        {
            g.pgsql.CodeFirst.SyncStructure<xxx>();
            var t3 = g.pgsql.Ado.Query<xxx, (int, string, string), dynamic>("select * from xxx; select * from xxx; select * from xxx");
        }

        class xxx
        {
            public string Id { get; set; }
            public string Path { get; set; }
            public string Title2 { get; set; }
        }
    }
}
