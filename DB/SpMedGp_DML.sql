USE SP_MEDICAL_GROUP_CSDMANHA;
GO

INSERT INTO usuario
VALUES ('Fernando Strada', 'fernandostrada@spmed.com', 'senhaadm1'),
('Ligia', 'ligia@gmail.com',	'123456'),
('Alexandre',	'alexandre@gmail.com', 'senhaale3'),
('Fernando', 'fernando@gmail.com', 'fernandoso'),
('Henrique', 'henrique@gmail.com', 'hen123'),
('João', 'joao@hotmail.com', 'jaosenha'),
('Bruno',	'bruno@gmail.com', 'brunedetto'),
('Mariana', 'mariana@outlook.com', 'marianabanana'),
('Ricardo Lemos',	'ricardo.lemos@spmedicalgroup.com.br', 'ricardoremos'),
('Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br',	'possarleliao'),
('Helena Strada',	'helena.souza@spmedicalgroup.com.br',	'estrada456');
GO

SELECT * FROM usuario;
GO

INSERT INTO administrador
VALUES (1, '12345678-91', '123456789-10');
GO

SELECT * FROM administrador;
GO

INSERT INTO especialidade
VALUES ('Acupuntura'),
('Anestesiologia'),
('Angiologia'),
('Cardiologia'),
('Cirurgia Cardiovascular'),
('Cirurgia da Mão'),
('Cirurgia do Aparelho Digestivo'),
('Cirurgia Geral'),
('Cirurgia Pediátrica'),
('Cirurgia Plástica'),
('Cirurgia Torácica'),
('Cirurgia Vascular'),
('Dermatologia'),
('Radioterapia'),
('Urologia'),
('Pediatria'),
('Psiquiatria');
GO

SELECT * FROM especialidade;
GO

INSERT INTO situacao
VALUES ('Realizada'),
('Agendada'),
('Cancelada');
GO

SELECT * FROM situacao;
GO

INSERT INTO clinica
VALUES (1, 'Clinica Possarle', 'SP Medical Group',	'86400902/0001-30', 'Av. Barão Limeira, 532, São Paulo, SP', '19:00:00', '22:00:00');
GO

SELECT * FROM clinica;
GO

INSERT INTO medico
VALUES (9,	1,	2,	'54356-SP'),
(10,	1,	17,	'53452-SP'),
(11,	1,	16,	'65463-SP');
GO

SELECT * FROM medico;
GO

INSERT INTO paciente 
VALUES 
(2,	'43.522.543-5',	'948.398.590-00',	'1983-10-13'),
(3,	'32.654.345-7',	'735.569.440-57',	'2001-07-23'),
(4,	'54.636.525-3',	'168.393.380-02',	'1978-10-10'),
(5,	'54.366.362-5',	'143.326.547-65',	'1985-10-13'),
(6,	'53.254.444-1',	'913.053.480-10',	'1975-08-27'),
(7,	'54.566.266-7',	'797.992.990-04',	'1972-03-21'),
(8,	'54.566.266-8',	'137.719.130-39',	'2018-03-05');
GO

SELECT * FROM paciente;
GO

INSERT INTO telefone
VALUES 
(2, '34567654'),
(3, '987656543'),
(4, '972084453'),
(5, '34566543'),
(6,	'76566377'),
(7,	'954368769');
GO

SELECT * FROM telefone;
GO


INSERT INTO consulta
VALUES 
(3,	1,	7,	'20/01/2020', '15:00:00', ''),
(2,	3,	2,	'06/01/2020', '10:00:00', ''),	
(2,	1,	3,	'07/02/2020', '11:00:00', ''),
(2,	1,	2,	'06/02/2018', '10:00:00', ''),	
(1,	3,	4,	'07/02/2019', '11:00:00', ''),	
(3,	2,	7,	'08/03/2020', '15:00:00', ''),	
(1,	2,	4,	'09/03/2020', '11:00:00', '');
GO

SELECT * FROM consulta;
GO