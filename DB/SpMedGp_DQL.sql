USE SP_MEDICAL_GROUP_CSDMANHA;
GO

---Busca das consultas de determinado médico
CREATE PROCEDURE buscaConsultaMedico
@indice varchar(10) 
WITH ENCRYPTION
AS
BEGIN
 SELECT dataConsulta 'Data da Consulta', nomeUsuario 'Paciente', descricaoSituacao 'Situação da consulta', descricaoConsulta 'Descrição da consulta' FROM consulta
 JOIN paciente
 ON paciente.idPaciente = consulta.idPaciente
 JOIN usuario
 ON usuario.idUsuario = paciente.idPaciente
 JOIN situacao
 ON situacao.idSituacao = consulta.idSituacao
 JOIN medico
 ON medico.idMedico = consulta.idMedico
 WHERE medico.crm = @indice;
 END
 GO

 ---Consultas do paciente
 CREATE PROCEDURE buscaConsultaPaciente
 @indice varchar(11)
 WITH ENCRYPTION
 AS
 BEGIN
 SELECT dataConsulta 'Data da Consulta', nomeUsuario 'Medico', descricaoSituacao 'Situação da consulta',descricaoConsulta 'Descrição da consulta' FROM consulta
 JOIN medico
 ON medico.idMedico = consulta.idMedico
 JOIN usuario
 ON usuario.idUsuario = medico.idUsuario
 JOIN situacao
 ON situacao.idSituacao = consulta.idSituacao
 JOIN paciente
 ON paciente.idPaciente = consulta.idPaciente
 WHERE paciente.rgPaciente = @indice
 END
 GO

 EXEC buscaConsultaMedico '';
 GO

 EXEC buscaConsultaPaciente '';
 GO

 ---Idade do paciente
 CREATE PROCEDURE cauculoIdade
 @indice varchar(11)
 WITH ENCRYPTION
 AS
 BEGIN
 SELECT nomeUsuario Paciente, rgPaciente Rg,  cpfPaciente Cpf, DATEDIFF(YYYY, dataNascimento, GETDATE()) 'Idade' FROM paciente
 JOIN usuario
 ON usuario.idUsuario = paciente.idUsuario
  WHERE paciente.rgPaciente = @indice
  END
  GO

  EXEC cauculoIdade '';
  GO


  ---Arrumando as datas de nascimento
  SELECT nomeUsuario Paciente, rgPaciente Rg, CONVERT(VARCHAR, dataNascimento, 101) 'Data de Nascimento' FROM paciente
 JOIN usuario
 ON usuario.idUsuario = paciente.idUsuario

   ---Arrumando as datas da Consulta
   SELECT CONVERT(VARCHAR, dataConsulta, 113)  'Data da Consulta', P.nomeUsuario 'Paciente', M.nomeUsuario 'Médico', descricaoSituacao 'Situação da consulta', descricaoConsulta 'Descrição da consulta' FROM consulta
 JOIN paciente
 ON paciente.idPaciente = consulta.idPaciente
 JOIN usuario P
 ON P.idUsuario = paciente.idPaciente
 JOIN situacao
 ON situacao.idSituacao = consulta.idSituacao
 JOIN medico
 ON medico.idMedico = consulta.idMedico
 JOIN usuario M
 On M.idUsuario = medico.IdUsuario;
 GO

 SELECT COUNT(idUsuario) AS 'Quantidade de usuarios' FROM usuario
