import React, { useState, useEffect } from "react";
import axios from "axios";
import { directive } from "@babel/types";

export default function consulta() {

    const [ListaConsultas, atualizaConsultas] = useState([]),
    const [IdMedico, atualizaIdMed] = useState(new int),
    const [IdSitucao, atualizaSituacao] = useState(new int),
    const [IdPaciente, atualizaPaciente] = useState(new int),
    const [DescricaoConsulta, atualizaDesc] = useState(''),
    const [DataConsulta, atualizaData] = useState(new Date),
    const [hora, atualizaHora] = useState(''),


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
    }
    return (
        <section className="main">
            <section className="quaseMain">
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
                            <span class="TTcampo">Descrição</span>
                            <p>Isso é um texto somente para testar a descrição e eu não quero por lorem ipsum entendeu?
                                sou
                                um dev de qualidade me contrata</p>
                        </div>
                    </div>
                    <div className="containerDir">
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
                        <img className="dodoi" src="undraw_injured_9757 1.png" alt=""/>
                    </div>
                </div>
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
            </section>
            <img className="criar" src="image 6.png" alt="" />
        </section>
    );
}