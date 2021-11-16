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
    const [IdMedico, atualizaIdMed] = useState(0)
    const [IdSitucao, atualizaSituacao] = useState(0)
    const [IdPaciente, atualizaPaciente] = useState(0)
    const [DescricaoConsulta, atualizaDesc] = useState('')
    const [DataConsulta, atualizaData] = useState(new Date())
    const [HorarioConsulta, atualizaHora] = useState('')


    function listarConsultas() {
        axios('http://localhost:5000/api/Consultums', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('user-logado')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaConsultas(resposta.data)
            }
        })
            .catch(erro => console.log(erro));
    }

    useEffect(listarConsultas, [])

    function listarMinhas() {
        axios('http://localhost:5000/api/Consultums', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('user-logado')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                atualizaConsultas(resposta.data)
            }
        })
            .catch(erro => console.log(erro));
    }

    function Cadastrar() {

    }

    function criarCardCadastrar() {
        return (
            <form onSubmit={Cadastrar()} className="cardPac">
                <div className="containerEsq">
                    <div>
                        <label for="idMedico" className="TTcampo">id Médico</label>
                        <input  value={IdMedico} id="idMedico" type="text" />
                    </div>
                    <div>
                        <label for="idSituacao" className="TTcampo">id Situação</label>
                        <input value={IdSitucao} id="idSituacao" type="text" />
                    </div>
                    <div>
                        <label for="Descricao" className="TTcampo">Descrição</label>
                        <input value={DescricaoConsulta} id="Descricao" type="text" />
                    </div>
                </div>
                <div class="containerDir">
                    <div>
                        <label for="idPaciente" className="TTcampo">id Paciente</label>
                        <input value={IdPaciente} id="idPaciente" type="text" />
                    </div>
                    <div>
                        <label for="dataCon" className="TTcampo">Data Consulta</label>
                        <input value={DataConsulta} id="dataCon" type="date"/>
                    </div>
                    <div>
                        <label for="horaCon" className="TTcampo">Horário Consulta</label>
                        <input value={HorarioConsulta} id="horaCon" type="time" />
                    </div>

                </div>
                <div className="alinhar">
                    <img className="dodoi" src="undraw_injured_9757 1.png" alt="" />
                    <div className="med">
                        <button type="submit"><img src="image 7 (2).png" alt=""/></button>
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
                            console.log(consultas)
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
                <button onClick={() => criarCardCadastrar}><img className="criar" src={criar} alt="" /></button> 
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