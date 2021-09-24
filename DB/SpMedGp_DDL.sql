CREATE DATABASE SP_MEDICAL_GROUP_CSDMANHA;
GO

USE SP_MEDICAL_GROUP_CSDMANHA;
GO

CREATE TABLE usuario(
idUsuario smallint primary key identity,
nomeUsuario varchar(50) NOT NULL,
emailUsuario varchar(256) NOT NULL UNIQUE,
senhaUsuario varchar(30) NOT NULL,
constraint userSenhaEmail UNIQUE(emailUsuario, senhaUsuario),
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
enderecoClinica varchar(300) NOT NULL UNIQUE,
horarioInicial time NOT NULL,
dataFinal time NOT NULL
);
GO

CREATE TABLE paciente(
idPaciente smallint primary key identity,
idUsuario smallint foreign key references usuario(idUsuario) NOT NULL UNIQUE,
rgPaciente varchar(12) NOT NULL UNIQUE,
constraint validarRg check( rgPaciente not like '[0-9][0-9].[0-9][0-9][0-9].[0-9][0-9][0-9]-[%]'),
cpfPaciente varchar(14) NOT NULL UNIQUE,
constraint validarCpf check( cpfPaciente not like '[0-9][0-9][0-9].[0-9][0-9][0-9].[0-9][0-9][0-9]-[%][%]'),
dataNascimento date NOT NULL
);
GO

CREATE TABLE medico(
idMedico smallint primary key identity,
idUsuario smallint foreign key references usuario(idUsuario) NOT NULL UNIQUE,
idClinica smallint foreign key references clinica(idClinica) NOT NULL,
idEspecialidade smallint foreign key references especialidade(idEspecialidade) NOT NULL,
crm varchar(8) NOT NULL UNIQUE,
constraint validarCrm check(crm like '[0-9][0-9][0-9][0-9][0-9]-[A-Z][A-Z]'),
);
GO

CREATE TABLE telefone(
idTelefone smallint primary key identity,
idPaciente smallint foreign key references paciente(idPaciente),
numeroTelefone varchar(9) NOT NULL
);
GO

CREATE TABLE consulta(
idConsulta smallint primary key identity,
idMedico smallint foreign key references medico(idMedico) NOT NULL,
idSituacao smallint foreign key references situacao(idSituacao) NOT NULL,
idPaciente smallint foreign key references paciente(idPaciente) NOT NULL,
dataConsulta date NOT NULL,
horarioConsulta time NOT NULL,
descricaoConsulta varchar(800) DEFAULT'Sem descrição'
);
GO