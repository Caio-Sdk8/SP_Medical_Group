USE SP_MEDICAL_GROUP;
GO

INSERT INTO usuario
VALUES ('Fernando Strada', 'fernandostrada@spmed.com', 'senhaadm1'),
('Ligia', 'ligia@gmail.com',	'123456'),
('Alexandre',	'alexandre@gmail.com', 'senhaale3'),
('Fernando', 'fernando@gmail.com', 'fernandoso'),
('Henrique', 'henrique@gmail.com', 'hen123'),
('Jo�o', 'joao@hotmail.com', 'jaosenha'),
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
('Cirurgia da M�o'),
('Cirurgia do Aparelho Digestivo'),
('Cirurgia Geral'),
('Cirurgia Pedi�trica'),
('Cirurgia Pl�stica'),
('Cirurgia Tor�cica'),
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
VALUES (1, 'Clinica Possarle', 'SP Medical Group',	'86400902/0001-30', 'Av. Bar�o Limeira, 532, S�o Paulo, SP');
GO

SELECT * FROM clinica;
GO

INSERT INTO medico
VALUES (9,	2,	2,	'54356-SP'),
(10,	2,	17,	'53452-SP'),
(11,	2,	16,	'65463-SP');
GO

SELECT * FROM medico;
GO

INSERT INTO paciente 
VALUES 
(2,	'43522543-5',	'94839859000',	'1983-10-13'),
(3,	'32654345-7',	'73556944057',	'2001-07-23'),
(4,	'54636525-3',	'16839338002',	'1978-10-10'),
(5,	'54366362-5',	'14332654765',	'1985-10-13'),
(6,	'53254444-1',	'91305348010',	'1975-08-27'),
(7,	'54566266-7',	'79799299004',	'1972-03-21'),
(8,	'54566266-8',	'13771913039',	'2018-03-05');
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
(3,	1,	7,	'20/01/2020 15:00',  ''),
(2,	3,	2,	'06/01/2020 10:00', ''),	
(2,	1,	3,	'07/02/2020 11:00', ''),
(2,	1,	2,	'06/02/2018 10:00', ''),	
(1,	3,	4,	'07/02/2019 11:00', ''),	
(3,	2,	7,	'08/03/2020 15:00', ''),	
(1,	2,	4,	'09/03/2020 11:00', '');
GO

SELECT * FROM consulta;
GO