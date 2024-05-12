using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Zadanie7.Models;

namespace Zadanie7.Migrations;

[DbContext((typeof(TripContext)))]
[Migration("InitialMigration")]
public partial class InitialMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
CREATE SCHEMA trip;
GO

CREATE TABLE trip.Client (
    IdClient int  NOT NULL,ss
    FirstName nvarchar(120)  NOT NULL,
    LastName nvarchar(120)  NOT NULL,
    Email nvarchar(120)  NOT NULL,
    Telephone nvarchar(120)  NOT NULL,
    Pesel nvarchar(120)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (IdClient)
);

CREATE TABLE trip.Client_Trip (
    IdClient int  NOT NULL,
    IdTrip int  NOT NULL,
    RegisteredAt datetime  NOT NULL,
    PaymentDate datetime  NULL,
    CONSTRAINT Client_Trip_pk PRIMARY KEY  (IdClient,IdTrip)
);

CREATE TABLE trip.Country (
    IdCountry int  NOT NULL,
    Name nvarchar(120)  NOT NULL,
    CONSTRAINT Country_pk PRIMARY KEY  (IdCountry)
);

CREATE TABLE trip.Country_Trip (
    IdCountry int  NOT NULL,
    IdTrip int  NOT NULL,
    CONSTRAINT Country_Trip_pk PRIMARY KEY  (IdCountry,IdTrip)
);

CREATE TABLE trip.Trip (
    IdTrip int  NOT NULL,
    Name nvarchar(120)  NOT NULL,
    Description nvarchar(220)  NOT NULL,
    DateFrom datetime  NOT NULL,
    DateTo datetime  NOT NULL,
    MaxPeople int  NOT NULL,
    CONSTRAINT Trip_pk PRIMARY KEY  (IdTrip)
);

ALTER TABLE trip.Country_Trip ADD CONSTRAINT Country_Trip_Country
    FOREIGN KEY (IdCountry)
    REFERENCES trip.Country (IdCountry);

ALTER TABLE trip.Country_Trip ADD CONSTRAINT Country_Trip_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES trip.Trip (IdTrip);

ALTER TABLE trip.Client_Trip ADD CONSTRAINT Table_5_Client
    FOREIGN KEY (IdClient)
    REFERENCES trip.Client (IdClient);

ALTER TABLE trip.Client_Trip ADD CONSTRAINT Table_5_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES trip.Trip (IdTrip);
""");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
ALTER TABLE trip.Country_Trip DROP CONSTRAINT Country_Trip_Country;

ALTER TABLE trip.Country_Trip DROP CONSTRAINT Country_Trip_Trip;

ALTER TABLE trip.Client_Trip DROP CONSTRAINT Table_5_Client;

ALTER TABLE trip.Client_Trip DROP CONSTRAINT Table_5_Trip;

DROP TABLE trip.Client;

DROP TABLE trip.Client_Trip;

DROP TABLE trip.Country;

DROP TABLE trip.Country_Trip;

DROP TABLE trip.Trip;
""");
    }
}