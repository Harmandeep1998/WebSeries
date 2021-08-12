USE [webseriesdb]
GO
SET IDENTITY_INSERT [dbo].[Platforms] ON 
GO
INSERT [dbo].[Platforms] ([Id], [PlatformName]) VALUES (1, N'YouTube')
GO
INSERT [dbo].[Platforms] ([Id], [PlatformName]) VALUES (2, N'Amazon Prime')
GO
INSERT [dbo].[Platforms] ([Id], [PlatformName]) VALUES (3, N'Netflix')
GO
INSERT [dbo].[Platforms] ([Id], [PlatformName]) VALUES (5, N'Disney HotStar')
GO
SET IDENTITY_INSERT [dbo].[Platforms] OFF
GO
SET IDENTITY_INSERT [dbo].[Seriess] ON 
GO
INSERT [dbo].[Seriess] ([Id], [SeriesName], [Language], [Season], [PlatformId]) VALUES (1, N'What the Folks', N'Hindi', 3, 1)
GO
INSERT [dbo].[Seriess] ([Id], [SeriesName], [Language], [Season], [PlatformId]) VALUES (2, N'Money Heist', N'English', 3, 3)
GO
INSERT [dbo].[Seriess] ([Id], [SeriesName], [Language], [Season], [PlatformId]) VALUES (3, N'Lucifer', N'English', 5, 3)
GO
INSERT [dbo].[Seriess] ([Id], [SeriesName], [Language], [Season], [PlatformId]) VALUES (4, N'Game of Thrones', N'English', 8, 5)
GO
INSERT [dbo].[Seriess] ([Id], [SeriesName], [Language], [Season], [PlatformId]) VALUES (5, N'Flash', N'English', 7, 2)
GO
INSERT [dbo].[Seriess] ([Id], [SeriesName], [Language], [Season], [PlatformId]) VALUES (6, N'Ray', N'Hindi', 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Seriess] OFF
GO
SET IDENTITY_INSERT [dbo].[Binges] ON 
GO
INSERT [dbo].[Binges] ([Id], [Comment], [SeriesId]) VALUES (1, N'Must Watch!!!', 1)
GO
INSERT [dbo].[Binges] ([Id], [Comment], [SeriesId]) VALUES (2, N'Thriller and very twisted ', 4)
GO
SET IDENTITY_INSERT [dbo].[Binges] OFF
GO
SET IDENTITY_INSERT [dbo].[SeriesRatings] ON 
GO
INSERT [dbo].[SeriesRatings] ([Id], [Review], [Rating], [SeriesId]) VALUES (1, N'The biggest Heist in the history. This is probably Netflix’s best and the most successful original show. In a bold story made up, full of original ideas, excellent acting, a lot of tense moments cleverly woven with funny moments- this is the jewel in the Netflix crown. The thing that keeps this show interesting is the fact that 3 different taking place at same time and three different places - The Inspector, The professor and the Heist. GREAT!!', 9, 2)
GO
INSERT [dbo].[SeriesRatings] ([Id], [Review], [Rating], [SeriesId]) VALUES (2, N'First things first, it''s very geeky. It''s got kings and knights, crowns and swords, dragons and ghosts. Medieval drama is a genre we get precious little of on television (or in movies, for that matter), and Game of Thrones has nearly 10 hours of it. Plus, the series of books boasts fans who are as serious about the happenings in Westeros – where most of the book''s action takes place – as any hardcore Trekkie or Star Wars geek is about those sagas.', 9, 4)
GO
SET IDENTITY_INSERT [dbo].[SeriesRatings] OFF
GO
