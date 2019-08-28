CREATE DATABASE Hire

USE Hire

CREATE TABLE [dbo].[Car](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleRegNo] [varchar](10) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[EngineSize] [varchar](10) NOT NULL,
	[DateRegistered] [date] NULL,
	[RentalPerDay] [decimal](8, 2) NOT NULL,
	[Available] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleRegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO Car (VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available)
VALUES ('BV557UTR','Mazda','1.6L','06-12-2007',90,0),
('GH376DRS','Ford','1.6L','04-13-2007',95,1),
('GV022JFG','Ford','1.4L','08-23-2006',65,0),
('HR483GHT','Honda','1.4L','03-24-2006',75,0),
('JK458YGD','Mercedes','1.6L','02-15-2007',120,0),
('KR385FWR','Nissan','1.4L','09-10-2006',65,1),
('PL324GHT','Nissan','1.2L','08-21-2006',55,0),
('PQ127RET','Fiat','1.4L','04-21-2007',80,0),
('PR674FHD','Ford','1.2L','08-04-2006',60,0),
('RK389TFW','Ford','1.6L','07-19-2007',120,0),
('RT543FRD','Fiat','1.4L','08-23-2006',75,0),
('TH237TPL','Mercedes','1.6L','01-08-2007',110,1),
('YR149HGE','Honda','1.4L','04-19-2007',85,0),
('YW903TFY','Honda','1.4L','06-05-2006',70,1),
('YZ782HJK','Mercedes','1.4L','09-12-2006',95,0);

SELECT * FROM Car