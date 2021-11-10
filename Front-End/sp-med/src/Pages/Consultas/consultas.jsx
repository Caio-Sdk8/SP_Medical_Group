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


    function listarConsultas(){
        axios('http://localhost:5000/api/Consultums',{
            headers : {
                Authorization : 'Bearer ' + localStorage.getItem('user-logado')
            }
        }).then(resposta =>{
            if(resposta.status === 200){
                atualizaConsultas(resposta.data)
            }
        })
    }
    return (
        <div></div>
    )
}