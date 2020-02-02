CREATE TABLE [dbo].[Count] (
    [CountId]      INT           NOT NULL,
    [SingleDouble] NVARCHAR (50) NULL,
    [Blend]        NVARCHAR (50) NULL,
    [CreatedBy]    NVARCHAR (50) NULL,
    [CreatedOn]    NVARCHAR (50) NULL,
    [ModifiedBy]   NVARCHAR (50) NULL,
    [ModifiedOn]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_Count] PRIMARY KEY CLUSTERED ([CountId] ASC)
);

