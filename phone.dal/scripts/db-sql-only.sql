CREATE TABLE [dbo].[Phone](
	[PHONE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
		[PHONE_CD] [varchar](2) NOT NULL,
			[PHONE_TX] [numeric](10, 0) NOT NULL,
				[CREATE_DT] [datetime] NOT NULL,
					[MOD_DT] [datetime] NOT NULL,
						[APPLICANT_ID] [numeric](18, 0) NOT NULL,
						 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
						 (
						 	[PHONE_ID] ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY]

							CREATE TABLE [dbo].[PhoneCD](
								[PHONE_CD] [varchar](2) NOT NULL,
									[PHONE_TX] [varchar](255) NOT NULL,
										[MOD_DT] [datetime] NOT NULL,
										 CONSTRAINT [PK_PhoneCD] PRIMARY KEY CLUSTERED 
										 (
										 	[PHONE_CD] ASC
											)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
											) ON [PRIMARY]

											ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_PhoneCD] FOREIGN KEY([PHONE_CD])
											REFERENCES [dbo].[PhoneCD] ([PHONE_CD])

											ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_PhoneCD]

