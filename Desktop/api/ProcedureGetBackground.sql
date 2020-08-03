CREATE PROCEDURE GetBackground
as

IF (FORMAT(GETDATE(), 'HH:mm') BETWEEN '09:00' and '21:30')
BEGIN
   select i.Id, i.Nome, i.Descricao, i.Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub 
   from Imagens i
   inner join Backgroundimage bi on bi.imageid = i.Id
   where isDia = 1
END
ELSE
BEGIN
    select i.Id, i.Nome, i.Descricao, i.Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub 
   from Imagens i
   inner join Backgroundimage bi on bi.imageid = i.Id
   where isDia = 0
end

--Verificar se proc está certa caso esteja dentro do horario
-- declare @DataMockada smalldatetime = (
--     select DATEADD(hour, -4, GETDATE())
-- )

-- PRINT @DataMockada;

-- IF (FORMAT(@DataMockada, 'HH:mm') BETWEEN '09:00' and '21:30')
-- BEGIN
--     PRINT 'Fui true'
-- END
-- ELSE
-- BEGIN
--     PRINT 'Fui false'
-- end


