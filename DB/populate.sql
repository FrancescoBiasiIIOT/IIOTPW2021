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


INSERT INTO [dbo].[Subjects]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
           ('4597d46e-5abf-494e-96cc-6f20110b43e2'
           ,'Sistemi',
		   '')
GO


INSERT INTO [dbo].[Subjects]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
           ('5a096e9a-5dd1-4b34-84c4-f2ed66c32941'
           ,'Soc e single board',
		   '')
GO

INSERT INTO [dbo].[Subjects]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
           ('d263a1bd-1d19-4f38-9186-779d2cbc0444'
           ,'Diritto aziendale',
		   '')
GO

INSERT INTO [dbo].[Subjects]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
           ('6aefe790-c5c7-461b-8cf5-e8a0596f4560'
           ,'Elettronica',
		   '')
GO

INSERT INTO [dbo].[Subjects]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
           ('85490d40-dd73-4c14-8531-e23de51cd6a2'
           ,'Programmazione C#',
		   '')
GO

INSERT INTO [dbo].[Subjects]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
           ('6787ac77-b407-4d02-9fd5-d0a0c7d9b1de'
           ,'sistemi embedded',
		   '')
GO


INSERT INTO [dbo].[Microcontrollers]
           ([Id]
           ,[DeviceId]
           ,[ClassroomId]
           ,[GatewayId])
     VALUES
           ('399f1f33-c6dc-47ae-9ab6-ac90123c9f60'
           ,'PIC01'
           ,'797842B3-6280-4EFA-B04D-11075CB75A2B'
           ,'49F3B0F1-0550-4148-B604-05F2BBB40AB6')
GO


INSERT INTO [dbo].[Microcontrollers]
           ([Id]
           ,[DeviceId]
           ,[ClassroomId]
           ,[GatewayId])
     VALUES
           ('70fa78fc-6fc4-406e-9204-32c9b73a058e'
           ,'PIC02'
           ,'3E7F0DAA-1E21-45C5-88D5-17E4BB59E481'
           ,'D6496A60-3DFB-438D-9146-069B1CC0201A')
GO


INSERT INTO [dbo].[Microcontrollers]
           ([Id]
           ,[DeviceId]
           ,[ClassroomId]
           ,[GatewayId])
     VALUES
           ('7b58e547-2cd0-4397-a4ec-f12e61257631'
           ,'PIC03'
           ,'303FB111-8FC1-4E40-A040-3A43A09A7326'
           ,'6728E870-6557-46FB-A9ED-29FAECD92E38')
GO


INSERT INTO [dbo].[Microcontrollers]
           ([Id]
           ,[DeviceId]
           ,[ClassroomId]
           ,[GatewayId])
     VALUES
           ('eaca1607-1543-4582-99d0-c0247736b5dd'
           ,'PIC04'
           ,'CA14F180-881B-43F6-8CBE-80B4F8F61AAC'
           ,'6E48857C-3A40-468F-BC7B-2E0B27CFF0A5')
GO


INSERT INTO [dbo].[Microcontrollers]
           ([Id]
           ,[DeviceId]
           ,[ClassroomId]
           ,[GatewayId])
     VALUES
           ('1fcf0837-44cb-4483-9234-cb0926f5acf8'
           ,'PIC05'
           ,'8B1B33DC-60B6-4480-A113-81FD30479E60'
           ,'35276DD7-4929-409D-8C11-D1F2C3C0A8D6')
GO

