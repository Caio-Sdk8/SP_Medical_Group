CREATE DATABASE SP_MEDICAL_GROUP;
GO

USE SP_MEDICAL_GROUP;
GO

CREATE TABLE usuario(
idUsuario smallint primary key identity,
nomeUsuario varchar(50) NOT NULL,
emailUsuario varchar(256) NOT NULL UNIQUE,
senhaUsuario varchar(30) NOT NULL
);
GO

CREATE TABLE situacao(
idSituacao smallint primary key identity,
descricaoSituacao varchar(200) NOT NULL UNIQUE
);
GO

CREATE TABLE especialidade(
idEspecialidade smallint primary key identity,
nomeEspecialidade varchar(70) NOT NULL UNIQUE
);
GO

CREATE TABLE administrador(
idAdministrador smallint primary key identity,
idUsuario smallint foreign key references usuario(idUsuario) NOT NULL UNIQUE,
rgAdministrador varchar(11) NOT NULL UNIQUE,
cpfAdministrador varchar(12) NOT NULL UNIQUE
);
GO

CREATE TABLE clinica(
idClinica smallint primary key identity,
idAdministrador smallint foreign key references administrador(idAdministrador) NOT NULL,
nomeClinica varchar(200) NOT NULL,
razaoSocial varchar(300) NOT NULL UNIQUE,
cnpj varchar(16) NOT NULL UNIQUE,
enderecoClinica varchar(300) NOT NULL UNIQUE
);
GO

CREATE TABLE paciente(
idPaciente smallint primary key identity,
idUsuario smallint foreign key references usuario(idUsuario) NOT NULL UNIQUE,
rgPaciente varchar(11) NOT NULL UNIQUE,
cpfPaciente varchar(12) NOT NULL UNIQUE,
dataNascimento date NOT NULL
);
GO

CREATE TABLE medico(
idMedico smallint primary key identity,
idUsuario smallint foreign key references usuario(idUsuario) NOT NULL UNIQUE,
idClinica smallint foreign key references clinica(idClinica) NOT NULL,
idEspecialidade smallint foreign key references especialidade(idEspecialidade) NOT NULL,
);
GO

CREATE TABLE telefone(
idTelefone smallint primary key identity,
idPaciente smallint foreign key references paciente(idPaciente) NOT NULL UNIQUE,
numeroTelefone varchar(9) NOT NULL
);
GO

CREATE TABLE consulta(
idConsulta smallint primary key identity,
idMedico smallint foreign key references medico(idMedico) NOT NULL,
idSituacao smallint foreign key references situacao(idSituacao) NOT NULL,
idPaciente smallint foreign key references paciente(idPaciente) NOT NULL,
dataConsulta smalldatetime NOT NULL,
descricaoConsulta varchar(800)
);
GO

ALTER TABLE medico
ADD crm varchar(10)
GO

