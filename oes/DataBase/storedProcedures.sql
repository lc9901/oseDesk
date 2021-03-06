USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procCheckCurrentIndexForQuestion]    Script Date: 09/05/2017 19:59:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procCheckCurrentIndexForQuestion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procCheckCurrentIndexForQuestion]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procCheckCurrentIndexForQuestion]    Script Date: 09/05/2017 19:59:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[procCheckCurrentIndexForQuestion]
	@examId int,
	@userId int
	
AS
BEGIN
	DECLARE @index int, @countExam int
	SET @index = 0 
	
	SET NOCOUNT ON;

	SELECT @countExam = COUNT(*) FROM user_exam WHERE [user_exam].[exam_id] = @examId AND [user_exam].[user_id] = @userId

    IF @countExam > 0
    BEGIN
        SELECT @index = COUNT(*) FROM answer_sheet AS eq WHERE eq.exam_id = @examId AND eq.[user_id] = @userId
    END
    ELSE
    BEGIN
        INSERT INTO [oesdata].[dbo].[user_exam]
           ([user_id] ,[exam_id] ,[exam_status] ,[score], [right_count])
        VALUES
           (@userId, @examId , 0, 0, 0)
    END
    
	RETURN @index
END


GO



--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procCommitTheAnswer]    Script Date: 09/05/2017 19:59:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procCommitTheAnswer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procCommitTheAnswer]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procCommitTheAnswer]    Script Date: 09/05/2017 19:59:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procCommitTheAnswer]
	-- Add the parameters for the stored procedure here
	@examId int ,
	@questionId int ,
	@userId int,
	@answer varchar(20),
	@rightAnswer varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [oesdata].[dbo].[answer_sheet]
                ([user_id]
                ,[exam_id]
                ,[question_id]
                ,[question_answer]
                ,[right_answer])
            VALUES
            ( @userId, @examId, @questionId , @answer, @rightAnswer)
END


GO
--======================================================================================
--======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procGetExamNotice]    Script Date: 09/05/2017 20:00:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procGetExamNotice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procGetExamNotice]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procGetExamNotice]    Script Date: 09/05/2017 20:00:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[procGetExamNotice]
	-- Add the parameters for the stored procedure here
	@userId int,
	@topQuality int,
	@diffTime int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	    T.id, T.name, T. effective_time 
	FROM 
	(
	    SELECT 
	        A.id,
            A.display_id,
            A.name,
            A.effective_time,
            row_number() over (order by  A.id   asc ) as number 
        FROM
            exam A LEFT JOIN user_exam B
                ON  
                    A.id = B.exam_id and  B.[user_id] = @userId
        WHERE
            (B.exam_status = 0 OR B.exam_status IS NULL ) AND DATEDIFF(minute, GETDATE(), A.effective_time) > -@diffTime
	    
	) T 
	WHERE T.number between 1 and @topQuality
END

GO

--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procLoginByUserName]    Script Date: 09/05/2017 20:01:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLoginByUserName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procLoginByUserName]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procLoginByUserName]    Script Date: 09/05/2017 20:01:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procLoginByUserName]
	-- Add the parameters for the stored procedure here
	@userName varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id]
      ,[user_name]
      ,[password]
      ,[gender]
      ,[role_type]
      ,[tel]
      ,[email]
      ,[avatar]
      ,[description]
      ,[address]
      ,[chinese_name]
      ,[create_time]
      ,[update_time]
      ,[last_login_time]
  FROM [oesdata].[dbo].[user]
  WHERE [user_name] = @userName
END

GO



--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procModifyTheLoginTime]    Script Date: 09/05/2017 20:02:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procModifyTheLoginTime]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procModifyTheLoginTime]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procModifyTheLoginTime]    Script Date: 09/05/2017 20:02:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[procModifyTheLoginTime]
	-- Add the parameters for the stored procedure here
	@id int,
	@lastLoginTime datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	UPDATE [user] SET last_login_time = @lastlogintime WHERE id = @id;
END


GO




--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryAbstractOfExam]    Script Date: 09/05/2017 20:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procQueryAbstractOfExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procQueryAbstractOfExam]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryAbstractOfExam]    Script Date: 09/05/2017 20:03:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procQueryAbstractOfExam]
	-- Add the parameters for the stored procedure here
	@examId int,
	@userId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id]
      ,[user_id]
      ,[exam_id]
      ,[exam_status]
      ,[score]
      ,[right_count]
      ,[use_time]
       FROM user_exam WHERE exam_id = @examId AND [user_id] = @userId
END


GO

--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryExamListByRequirement]    Script Date: 09/05/2017 20:04:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procQueryExamListByRequirement]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procQueryExamListByRequirement]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryExamListByRequirement]    Script Date: 09/05/2017 20:04:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[procQueryExamListByRequirement]
	@currentPage int,
    @pageSize int,
    @userId int,
    @examStatus nvarchar(50) = 'All',
    @sortColume nvarchar(50) = 'id ',
    @sortWay nvarchar(50) = ' asc '
	
AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @startRow nvarchar(100),
            @endRow nvarchar(100), 
            @Sql nvarchar(2000),
            @SelectFields nvarchar(2000),
            @sqlWherePage nvarchar(2000),
            @examStatusWhere nvarchar(100)
    
    SET @startRow = (@currentPage - 1) * @pageSize +1
    SET @endRow = @startRow + @pageSize -1
    
    IF @sortColume = ' '
    BEGIN
        SET @sortColume = 'id '
    END
    
    IF @sortWay = ' '
    BEGIN
        SET @sortWay = ' asc '
    END
    
    
    IF @sortColume IN ('score', 'exam_status')
    BEGIN
        SET @sortColume = ' B.' + @sortColume
    END
    ELSE
    BEGIN
        SET @sortColume = ' A.' + @sortColume
    END
    
    SET @SelectFields ='
                        A.id,
                        A.display_id,
                        A.name,
                        A.effective_time,
                        A.time_limit,
                        A.pass_criteria,
                        A.total_score,
                        B.score,
                        B.exam_status, 
                        row_number() over (order by ' + @sortColume + ' ' + @sortWay + ') as number 
                        '
    
    SET @examStatusWhere = ' B.[user_id] = ' + CAST(@userId AS nvarchar(20)) 
      IF @examStatus = 'unfinished'
      BEGIN
        SET @examStatusWhere = @examStatusWhere + ' WHERE  B.exam_status IS NULL OR B.exam_status = 0'
      END
      ELSE IF @examStatus = 'finished'
      BEGIN
        SET @examStatusWhere = @examStatusWhere + ' WHERE  B.exam_status = 1 OR B.exam_status = 2'
      END
    
    
    SET @sqlWherePage = 'T.number between ' + CAST(@startRow AS nvarchar(20)) +
                        ' and ' + CAST(@endRow AS nvarchar(20));
    
    SET @Sql = 'select 
                        T.id, T.display_id, T.name, T.effective_time, T.time_limit,
                        T.pass_criteria, T.total_score, T.score, T.exam_status, T.number
                   from (
                             SELECT 
                             ' +
                                 @SelectFields
                                 + '
                              FROM [exam] A  left join [user_exam] B on  A.id = B.exam_id
                              and ' + @examStatusWhere
    
              + ') T where ' + @sqlWherePage;
	EXEC(@sql)

	
	SET @Sql = 'SELECT 
                COUNT(1) AS totalCount
                FROM [exam] A left join [user_exam] B on A.id = B.exam_id
                and ' + @examStatusWhere
              
	EXEC (@sql)
	 
	      
END


GO

--=======================================================================================
--=======================================================================================

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryExamListByTeacher]    Script Date: 09/05/2017 20:05:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procQueryExamListByTeacher]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procQueryExamListByTeacher]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryExamListByTeacher]    Script Date: 09/05/2017 20:05:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procQueryExamListByTeacher]
	-- Add the parameters for the stored procedure here
	@pageSize int,
	@currentPage int,
	@totalCount int = 0 out,
	@sortColume nvarchar(50) = 'id ',
    @sortWay nvarchar(50) = ' asc '
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @startRow int, @endRow int, @sql varchar(1000)
	
	SET @startRow = (@currentPage - 1) * @pageSize +1
    SET @endRow = @startRow + @pageSize -1

    -- Insert statements for procedure here
    SET @sql = 'SELECT 
                  id, name, display_id, effective_time, question_quantity, pass_criteria,
                  average_score, examinee_count, pass_number, pass_rate
               FROM (   
               SELECT 
                  id, name, display_id, effective_time, question_quantity, pass_criteria, average_score, examinee_count,
	              pass_number, pass_rate,row_number() over (order by ' + @sortColume + ' ' + @sortWay + ') as number 
               ' + 'FROM exam  ) T WHERE T.number  between ' + CAST(@startRow AS nvarchar(20)) +
                        ' and ' + CAST(@endRow AS nvarchar(20));
	EXEC(@sql)  
	
SELECT @totalCount = COUNT(id) FROM exam
         
END

GO



--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryOneExamSummary]    Script Date: 09/05/2017 20:05:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procQueryOneExamSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procQueryOneExamSummary]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procQueryOneExamSummary]    Script Date: 09/05/2017 20:05:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procQueryOneExamSummary]
	-- Add the parameters for the stored procedure here
	@examId int,
	@userId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	    a.id, a.display_id, a.[user_id], a.name, a.total_score, a.question_quantity, a.single_question_score,
	    a.create_time, a.[description], a.effective_time, a.pass_criteria, a.time_limit, a.examinee_count
	
	, b.use_time FROM exam a LEFT JOIN user_exam b ON a.id = b.exam_id AND b.[user_id] = @userId  WHERE a.id = @examId 
END



GO


--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSelectOneExamResultDetailByExamAndUserId]    Script Date: 09/05/2017 20:06:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procSelectOneExamResultDetailByExamAndUserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procSelectOneExamResultDetailByExamAndUserId]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSelectOneExamResultDetailByExamAndUserId]    Script Date: 09/05/2017 20:06:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procSelectOneExamResultDetailByExamAndUserId]
	-- Add the parameters for the stored procedure here
	@examId int,
	@userId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.id, A.name, A.display_id, A.effective_time, A.time_limit , A.question_quantity, A.total_score, B.score, B.right_count FROM exam A LEFT JOIN user_exam B ON A.id = B.exam_id WHERE A.id = @examId AND B.[user_id] = @userId
END


GO


--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSelectQuestionOfCurrentExam]    Script Date: 09/05/2017 20:07:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procSelectQuestionOfCurrentExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procSelectQuestionOfCurrentExam]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSelectQuestionOfCurrentExam]    Script Date: 09/05/2017 20:07:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procSelectQuestionOfCurrentExam]
	-- Add the parameters for the stored procedure here
	@examId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT q.id, q.[description], q.answer, q.option_a, q.option_b, q.option_c, q.option_d FROM [question] as q WHERE q.id in (
	
	SELECT question_id FROM [exam_question] where exam_id = @examId
	)
	
	
END


GO



--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSelectTheAnswerList]    Script Date: 09/05/2017 20:08:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procSelectTheAnswerList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procSelectTheAnswerList]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSelectTheAnswerList]    Script Date: 09/05/2017 20:08:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procSelectTheAnswerList]
	-- Add the parameters for the stored procedure here
	@examId int,
	@userId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*, b.[description], b.option_a, b.option_b, b.option_c, b.option_d  FROM answer_sheet a JOIN question b on a.question_id = b.id WHERE  a.[user_id] = @userId AND a.exam_id = @examId
END


GO




--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSetExamStatusToFinished]    Script Date: 09/06/2017 10:23:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procSetExamStatusToFinished]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procSetExamStatusToFinished]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procSetExamStatusToFinished]    Script Date: 09/06/2017 10:23:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procSetExamStatusToFinished]
	-- Add the parameters for the stored procedure here
	@userId INT,
	@examId INT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @examScore INT, @passScore INT, @averageScore int, @examineeCount int, @passCount int
	
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	BEGIN TRAN
	
	SELECT @passScore = pass_criteria FROM exam WHERE exam.id = @examId
	SELECT @examScore = score FROM user_exam WHERE  user_exam.[user_id] = @userId AND user_exam.exam_id = @examId
	SELECT @averageScore = average_score, @examineeCount = examinee_count, @passCount = pass_number FROM exam WHERE exam.id = @examId
	
	
	IF(@examScore > @passScore)
	BEGIN
        UPDATE user_exam SET exam_status = 2 WHERE [user_id] = @userId AND exam_id = @examId
	    UPDATE exam SET
	        average_score = (@averageScore * @examineeCount + @examScore) / (@examineeCount +1), 
	        examinee_count = @examineeCount + 1,
	        pass_number = @passCount + 1,
	        pass_rate = (@passCount + 1 ) * 100 / (@examineeCount + 1)
	    WHERE id = @examId
	END
	ELSE
	BEGIN
        UPDATE user_exam SET exam_status = 1 WHERE [user_id] = @userId AND exam_id = @examId
	    UPDATE exam SET
	        average_score = (@averageScore * @examineeCount + @examScore) / (@examineeCount +1), 
	        examinee_count = @examineeCount + 1,
	        pass_rate = (@passCount) * 100 / (@examineeCount + 1)
	    WHERE id = @examId
	END
	
	COMMIT
	
END


GO


--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procUpdateExamUseTime]    Script Date: 09/05/2017 20:09:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procUpdateExamUseTime]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procUpdateExamUseTime]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procUpdateExamUseTime]    Script Date: 09/05/2017 20:09:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procUpdateExamUseTime]
	-- Add the parameters for the stored procedure here
	@userId int,
	@examId int,
	@intervalTime int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @maxUseTime int, @currentUseTime int
    SELECT @maxUseTime = time_limit * 60 FROM exam WHERE id = @examId
    SELECT @currentUseTime = use_time FROM user_exam WHERE [user_id] = @userId AND [exam_id] = @examId
    IF(@currentUseTime + @intervalTime > @maxUseTime)
    BEGIN
	UPDATE user_exam SET use_time = @maxUseTime WHERE [user_id] = @userId AND [exam_id] = @examId
   
    END
    ELSE
    BEGIN
	UPDATE user_exam SET use_time = use_time + @intervalTime WHERE [user_id] = @userId AND [exam_id] = @examId
    END
	
	
END


GO



--=======================================================================================
--=======================================================================================
USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procUpdateScoreToExam]    Script Date: 09/05/2017 20:09:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procUpdateScoreToExam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procUpdateScoreToExam]
GO

USE [oesdata]
GO

/****** Object:  StoredProcedure [dbo].[procUpdateScoreToExam]    Script Date: 09/05/2017 20:09:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procUpdateScoreToExam]
	-- Add the parameters for the stored procedure here
	@examId int,
	@userId int,
	@singleScore int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @maxScore int,@maxCont int, @currentScoer int
    SELECT @currentScoer = score FROM user_exam WHERE exam_id = @examId AND [user_id] = @userId
    SELECT @maxScore = total_score, @maxCont = question_quantity FROM exam WHERE id = @examId
    
    IF (@currentScoer + @singleScore > @maxScore)
    BEGIN
	    UPDATE user_exam SET score = @maxScore, right_count = @maxCont WHERE exam_id = @examId AND [user_id] = @userId
    END
    ELSE
    BEGIN
	    UPDATE user_exam SET score = score + @singleScore, right_count = right_count + 1 WHERE exam_id = @examId AND [user_id] = @userId
    END

END


GO




--=======================================================================================
--=======================================================================================
