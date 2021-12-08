import React, { useState, useEffect } from "react";
import axios from "axios";
import { parseJwt } from '../../services/auth';
import { directive } from "@babel/types";
import { render } from "react-dom";
import './consultas.css';
import dodoi from '../Assets/undraw_injured_9757 1.png';
import lapis from '../Assets/image 7.png';
import criar from '../Assets/image 6.png'

export default function Consulta() {

    const [ListaConsultas, atualizaConsultas] = useState([])
    const [ListaMed, atualizaListMed] = useState([])
    const [ListaPac, atualizaListPac] = useState([])
    const [ListaSituac, atualizaSituac] = useState([])
    const [IdMedico, atualizaIdMed] = useState(0)
    const [IdSitucao, atualizaSituacao] = useState(0)
    const [IdPaciente, atualizaPaciente] = useState(0)
    const [DescricaoConsulta, atualizaDesc] = useState('')
    const [DataConsulta, atualizaData] = useState(new Date())
    const [HorarioConsulta, atualizaHora] = useState('')
    const [cadastro, atualizaCad] = useState(new Boolean(false))
    const [carregando, estaCarregando] = useState(false);


    function listarConsultas() {
        axios('http://localhost:5000/api/Consultums', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaConsultas(resposta.data)
            }
        })
            .catch(erro => console.log(erro));

    }

    useEffect(listarConsultas, [])

    function listarMed() {
        axios('http://localhost:5000/api/Medicos', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaListMed(resposta.data)
                console.log("querida, cheguei")
            }
        })
            .catch(erro => console.log(erro));

    }
    useEffect(listarMed, [])

    function listarPac() {
        axios('http://localhost:5000/api/Pacientes', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaListPac(resposta.data)
            }
        })
            .catch(erro => console.log(erro));

    }

    useEffect(listarPac, [])

    function listarSitucao() {
        axios('http://localhost:5000/api/Situacaos', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaSituac(resposta.data)
            }
        })
            .catch(erro => console.log(erro));

    }

    useEffect(listarSitucao, [])
    function listarMinhas() {
        axios('http://localhost:5000/api/Consultums', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaConsultas(resposta.data)
            }
        })
            .catch(erro => console.log(erro));
    }

    function Cadastrar(evento) {

        evento.preventDefault();

        estaCarregando(true);

        if (ListaConsultas) {
        }

        axios.post('http://localhost:5000/api/Consultums', {
            HorarioConsulta : HorarioConsulta,
            IdMedico : IdMedico,
            IdPaciente : IdPaciente,
            DataConsulta : DataConsulta,
            DescricaoConsulta : DescricaoConsulta,
            IdSitucao : IdSitucao
        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('consultinhas');
                    listarConsultas();
                    atualizaHora('');
                    atualizaIdMed(0);
                    atualizaSituacao(0);
                    atualizaPaciente(0);
                    atualizaDesc('');
                    atualizaData(new Date());
                    estaCarregando(false);
                }
            })
            .catch(erro => console.log(erro), setInterval(() => {
                estaCarregando(false)
            }, 5000));

    }

    function criarCardCadastrar() {
        return (
            <form onSubmit={() => Cadastrar()} className="cardPac">
                <div className="containerEsq">
                    <div>
                        <label for="idMedico" className="TTcampo">id Médico</label>
                        <select
                            id="idMedico"
                            name="idMedico"
                            value={IdMedico}
                            onChange={(campo) => atualizaIdMed(campo.target.value)}
                        >
                            <option value="0" selected disabled>
                                Selecione o Id do Médico
                            </option>

                            {ListaMed.map((med) => {
                                return (
                                    <option key={med.IdMedico} value={med.IdMedico}>
                                        {med.idUsuarioNavigation.nomeUsuario}
                                    </option>
                                );
                            })}
                        </select>
                    </div>
                    <div>
                        <label for="idSituacao" className="TTcampo">id Situação</label>
                        <select
                            id="idSituacao"
                            name="idSituacao"
                            value={IdSitucao}
                            onChange={(campo) => atualizaSituacao(campo.target.value)}
                        >
                            <option value="0" selected disabled>
                                Selecione o Id da Situação
                            </option>

                            {ListaSituac.map((sit) => {
                                return (
                                    <option key={sit.IdSitucao} value={sit.IdSitucao}>
                                        {sit.descricaoSituacao}
                                    </option>
                                );
                            })}
                        </select>
                    </div>
                    <div>
                        <label for="Descricao" className="TTcampo">Descrição</label>
                        <input value={DescricaoConsulta} id="Descricao" type="text" onChange={(campo) => atualizaDesc(campo.target.value)} />
                    </div>
                </div>
                <div class="containerDir">
                    <div>
                        <label for="idPaciente" className="TTcampo">id Paciente</label>
                        <select
                            id="idPaciente"
                            name="idPaciente"
                            value={IdPaciente}
                            onChange={(campo) => atualizaPaciente(campo.target.value)}
                        >
                            <option value="0" selected disabled>
                                Selecione o Id do Paciente
                            </option>

                            {ListaPac.map((pac) => {
                                return (
                                    <option key={pac.IdPaciente} value={pac.IdPaciente}>
                                        {pac.idUsuarioNavigation.nomeUsuario}
                                    </option>
                                );
                            })}
                        </select>
                    </div>
                    <div>
                        <label for="dataCon" className="TTcampo">Data Consulta</label>
                        <input value={DataConsulta} id="dataCon" type="date" onChange={(campo) => atualizaData(campo.target.value)} />
                    </div>
                    <div>
                        <label for="horaCon" className="TTcampo">Horário Consulta</label>
                        <input value={HorarioConsulta} id="horaCon" type="time" onChange={(campo) => atualizaHora(campo.target.value)} />
                    </div>

                </div>
                <div className="alinhar">
                    <img className="dodoi" src=
                        {dodoi} alt="" />
                    <div className="med">
                        <button type="submit" className="CriarCad"><img src={criar} className="imgCrCd" alt="" /></button>
                    </div>
                </div>
            </form>
        )
    }

    if (parseJwt().role === '1') {
        return (
            <section className="main">
                <section className="quaseMain">
                    {
                        ListaConsultas.map((consultas) => {
                            return (
                                <div className="cardPac">
                                    <div className="containerEsq">
                                        <div>
                                            <span className="TTcampo">Médico</span>
                                            <p>{consultas.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Situação</span>
                                            <p>{consultas.idSituacaoNavigation.descricaoSituacao}</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Descrição</span>
                                            <p>{consultas.descricaoConsulta}</p>
                                        </div>
                                    </div>
                                    <div class="containerDir">
                                        <div>
                                            <span className="TTcampo">Paciente</span>
                                            <p>{consultas.idPacienteNavigation.idUsuarioNavigation.nomeUsuario}</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Data Consulta</span>
                                            <p>{consultas.dataConsulta}</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Horário Consulta</span>
                                            <p>{consultas.horarioConsulta}</p>
                                        </div>

                                    </div>
                                    <div className="alinhar">
                                        <img className="dodoi" src={dodoi} alt="" />
                                        <div className="med">
                                            <img src={lapis} alt="" />
                                        </div>
                                    </div>
                                </div>
                            )

                        })
                    }

                </section>
                <button onClick={() => atualizaCad(true)} className="criar"><img src={criar} alt="" /></button>
                {cadastro == true && (
                    criarCardCadastrar()
                )}

            </section>
        );
    }

    else if (parseJwt().role === '3') {
        return (
            <section className="main">
                <section className="quaseMain">
                    {

                        ListaConsultas.map((consultas) => {
                            return (
                                <div className="cardPac">
                                    <div className="containerEsq">
                                        <div>
                                            <span className="TTcampo">Médico</span>
                                            <p>Nome do médico</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Situação</span>
                                            <p>Situação</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Descrição</span>
                                            <p>Isso é um texto somente para testar a descrição e eu não quero por lorem ipsum entendeu?
                                                sou
                                                um dev de qualidade me contrata</p>
                                        </div>
                                    </div>
                                    <div class="containerDir">
                                        <div>
                                            <span className="TTcampo">Paciente</span>
                                            <p>Nome Paciente</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Data Consulta</span>
                                            <p>00/00/0000</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Horário Consulta</span>
                                            <p>00:00</p>
                                        </div>

                                    </div>
                                    <div className="alinhar">
                                        <img className="dodoi" src="undraw_injured_9757 1.png" alt="" />
                                        <div className="med">
                                            <img src="image 7.png" alt="" />
                                        </div>
                                    </div>
                                </div>
                            )

                        })
                    }
                </section>
            </section>
        );
    }

    else if (parseJwt().role === '2') {
        return (
            <section className="main">
                <section className="quaseMain">
                    {

                        ListaConsultas.map((consultas) => {
                            return (
                                <div className="cardPac">
                                    <div className="containerEsq">
                                        <div>
                                            <span className="TTcampo">Médico</span>
                                            <p>Nome do médico</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Situação</span>
                                            <p>Situação</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Descrição</span>
                                            <p>Isso é um texto somente para testar a descrição e eu não quero por lorem ipsum entendeu?
                                                sou
                                                um dev de qualidade me contrata</p>
                                        </div>
                                    </div>
                                    <div class="containerDir">
                                        <div>
                                            <span className="TTcampo">Paciente</span>
                                            <p>Nome Paciente</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Data Consulta</span>
                                            <p>00/00/0000</p>
                                        </div>
                                        <div>
                                            <span className="TTcampo">Horário Consulta</span>
                                            <p>00:00</p>
                                        </div>

                                    </div>
                                    <div className="alinhar">
                                        <img className="dodoi" src="undraw_injured_9757 1.png" alt="" />
                                    </div>
                                </div>
                            )

                        })
                    }
                </section>
            </section>
        );
    }
}