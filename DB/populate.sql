INSERT INTO [dbo].[Buildings]
           ([Id]
           ,[Building_Name]
           ,[Description])
     VALUES
           ('94e51edf-22ca-4d26-b5f7-9b9b9bcd6bc7'
           ,'S'
           ,'Edificio S')
GO

INSERT INTO [dbo].[Buildings]
           ([Id]
           ,[Building_Name]
           ,[Description])
     VALUES
           ('b01dc575-af11-4ebb-955e-f1ae227eee8f'
           ,'L'
           ,'Edificio L')
GO


/*EDIFICO S */
INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('2507a129-9380-419b-bb43-580154fe400f'
           ,'94e51edf-22ca-4d26-b5f7-9b9b9bcd6bc7'
           ,0)
GO

INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('075030e7-b3e4-4a79-8550-06eb4a373889'
           ,'94e51edf-22ca-4d26-b5f7-9b9b9bcd6bc7'
           ,1)
GO

INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('5fd12cf3-71cf-4313-90a7-07482c980c79'
           ,'94e51edf-22ca-4d26-b5f7-9b9b9bcd6bc7'
           ,2)
GO


INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('4a59854f-63b9-4f14-b2bf-a27b084f8d92'
           ,'94e51edf-22ca-4d26-b5f7-9b9b9bcd6bc7'
           ,3)
GO


/*EDIFICO L */
INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('e5314e84-579d-408a-b311-caf3ba85e7dc'
           ,'b01dc575-af11-4ebb-955e-f1ae227eee8f'
           ,0)
GO

INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('753768a2-f04b-4e02-b22c-e35775f42004'
           ,'b01dc575-af11-4ebb-955e-f1ae227eee8f'
           ,1)
GO

INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('7a08c9a0-4f53-4f32-a6ac-bddb037b3a6f'
           ,'b01dc575-af11-4ebb-955e-f1ae227eee8f'
           ,2)
GO


INSERT INTO [dbo].[FloorsBuilding]
           ([Id]
           ,[BuildingId]
           ,[Floor])
     VALUES
           ('d97fce59-570b-496c-9bb7-18965f251ebb'
           ,'b01dc575-af11-4ebb-955e-f1ae227eee8f'
           ,3)
GO


INSERT INTO [dbo].[Teachers]
           ([Id]
           ,[Name]
           ,[Surname]
           ,[Date])
     VALUES
           ('760cc8c2-4887-4304-a0a6-b4609f8f4233'
           ,'Andrea'
           ,'Dottor'
           ,'1980/01/01')
GO

INSERT INTO [dbo].[Teachers]
           ([Id]
           ,[Name]
           ,[Surname]
           ,[Date])
     VALUES
           ('56542f70-8e0d-43ea-ab4b-6a3fc2b29ad3'
           ,'Daniele'
           ,'Gobbo'
           ,'1970/03/01')
GO


INSERT INTO [dbo].[Teachers]
           ([Id]
           ,[Name]
           ,[Surname]
           ,[Date])
     VALUES
           ('63bce001-133b-41c7-b0a8-f3c9876a2244'
           ,'Stefano'
           ,'Valle'
           ,'1980/07/04')
GO

INSERT INTO [dbo].[Teachers]
           ([Id]
           ,[Name]
           ,[Surname]
           ,[Date])
     VALUES
           ('183a4f80-9b53-4914-8000-fbc8752b899e'
           ,'Andrea'
           ,'Piccin'
           ,'1990/07/04')
GO



INSERT INTO [dbo].[Classrooms]
           ([Id]
           ,[Name]
           ,[State]
           ,[Capacity]
           ,[FloorId])
     VALUES
           ('3e7f0daa-1e21-45c5-88d5-17e4bb59e481'
           ,'1'
           ,0
           ,30
           ,'2507a129-9380-419b-bb43-580154fe400f')
GO

INSERT INTO [dbo].[Classrooms]
           ([Id]
           ,[Name]
           ,[State]
           ,[Capacity]
           ,[FloorId])
     VALUES
           ('8b1b33dc-60b6-4480-a113-81fd30479e60'
           ,'2'
           ,0
           ,30
           ,'2507a129-9380-419b-bb43-580154fe400f')
GO

INSERT INTO [dbo].[Classrooms]
           ([Id]
           ,[Name]
           ,[State]
           ,[Capacity]
           ,[FloorId])
     VALUES
           ('303fb111-8fc1-4e40-a040-3a43a09a7326'
           ,'3'
           ,0
           ,30
           ,'2507a129-9380-419b-bb43-580154fe400f')
GO


INSERT INTO [dbo].[Classrooms]
           ([Id]
           ,[Name]
           ,[State]
           ,[Capacity]
           ,[FloorId])
     VALUES
           ('3b8d13a7-4bdf-4c58-9a6f-fbcd1ab7edef'
           ,'1'
           ,0
           ,30
           ,'e5314e84-579d-408a-b311-caf3ba85e7dc')
GO



INSERT INTO [dbo].[Classrooms]
           ([Id]
           ,[Name]
           ,[State]
           ,[Capacity]
           ,[FloorId])
     VALUES
           ('ca14f180-881b-43f6-8cbe-80b4f8f61aac'
           ,'2'
           ,0
           ,30
           ,'e5314e84-579d-408a-b311-caf3ba85e7dc')
GO



INSERT INTO [dbo].[Classrooms]
           ([Id]
           ,[Name]
           ,[State]
           ,[Capacity]
           ,[FloorId])
     VALUES
           ('797842b3-6280-4efa-b04d-11075cb75a2b'
           ,'3'
           ,0
           ,30
           ,'e5314e84-579d-408a-b311-caf3ba85e7dc')
GO



INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('49f3b0f1-0550-4148-b604-05f2bbb40ab6'
           ,'RB100'
           ,'2507a129-9380-419b-bb43-580154fe400f')
GO


INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('687dabbd-e735-40be-a3d7-f173eeb036ef'
           ,'RB101'
           ,'075030e7-b3e4-4a79-8550-06eb4a373889')
GO

INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('d6496a60-3dfb-438d-9146-069b1cc0201a'
           ,'RB102'
           ,'5fd12cf3-71cf-4313-90a7-07482c980c79')
GO
INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('35276dd7-4929-409d-8c11-d1f2c3c0a8d6'
           ,'RB103'
           ,'4a59854f-63b9-4f14-b2bf-a27b084f8d92')
GO



INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('6728e870-6557-46fb-a9ed-29faecd92e38'
           ,'RB200'
           ,'e5314e84-579d-408a-b311-caf3ba85e7dc')
GO


INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('6e48857c-3a40-468f-bc7b-2e0b27cff0a5'
           ,'RB201'
           ,'753768a2-f04b-4e02-b22c-e35775f42004')
GO

INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('a540ebce-fb7e-4495-b94d-87e282f100c6'
           ,'RB202'
           ,'7a08c9a0-4f53-4f32-a6ac-bddb037b3a6f')
GO
INSERT INTO [dbo].[Gateways]
           ([Id]
           ,[GatewayId]
           ,[FloorId])
     VALUES
           ('b74b5b4d-f939-4cf9-bcf0-ae9b36e3b50a'
           ,'RB203'
           ,'d97fce59-570b-496c-9bb7-18965f251ebb')
GO



