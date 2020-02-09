CREATE TABLE [dbo].[Count] (
    [CountId]      INT            IDENTITY (1, 1) NOT NULL,
    [CountName]    NVARCHAR (50)  NULL,
    [SingleDouble] NVARCHAR (50)  NULL,
    [Blend]        INT            NULL,
    [Description]  NVARCHAR (200) NULL,
    [CreatedBy]    NVARCHAR (50)  NULL,
    [CreatedOn]    DATETIME       NULL,
    [ModifiedBy]   NVARCHAR (50)  NULL,
    [ModifiedOn]   DATETIME       NULL,
    CONSTRAINT [PK_Count] PRIMARY KEY CLUSTERED ([CountId] ASC),
    CONSTRAINT [FK_Count_Blend] FOREIGN KEY ([Blend]) REFERENCES [dbo].[Blend] ([BlendId])
);



