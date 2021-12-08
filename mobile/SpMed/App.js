/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow strict-local
 */

import React, { Component } from 'react';
import image from './Src/assets/FundBan.png';
import urologia from './Src/assets/Urologia.png';
import acupuntura from './Src/assets/Acupuntura.png';
import cirurgias from './Src/assets/Cirurgias.png';
import {
  SafeAreaView,
  Image,
  ImageBackground,
  ScrollView,
  StatusBar,
  StyleSheet,
  Text,
  useColorScheme,
  View,
} from 'react-native';

import {
  Colors,
  DebugInstructions,
  Header,
  LearnMoreLinks,
  ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';

class App extends Component {
  render() {
    return (
      <ScrollView style={styles.main}>
        <Text >Teste</Text>
        <ImageBackground source={image} resizeMode="cover" style={styles.image}>
          <View style={styles.banner}>
            <View style={styles.textBan}>
              <Text style={styles.tituloBan}>Sp Medical Group</Text>
              <Text style={styles.text}>Bem vinde a Sp Medical Group, a clinica que já cuida de você a um ano, agora online, com os procedimentos ainda mais praticos, para que com nossos serviços possamos cuidar de quem realmente importa, você.</Text>
            </View>
          </View>
        </ImageBackground>
        <View style={styles.areaServ}>
          <Text style={styles.verdinha}>Serviços</Text>
          <View style={styles.serv}>
            <Image source={acupuntura}>
            </Image>
            <Image source={urologia}>
            </Image>
            <Image source={cirurgias}>
            </Image>
          </View>
        <Text style={styles.sera}>
          E várias outras especializações apenas para trazer o melhor, à você.
        </Text>
        </View>
      </ScrollView >
    )

  }
}

const styles = StyleSheet.create({
  main : {
    backgroundColor : '#F9FFF8'
  },
  image: {
    height: 300
  },
  banner: {
    width: '100%',
    height: 300,
    justifyContent: 'center',
    alignItems: 'flex-end',
    padding: 30
  },
  textBan: {
    width: '38%',
    fontFamily: 'SawarabiGothic-Regular',
  },
  tituloBan: {
    textTransform: 'uppercase',
    color: '#FFFFFF'
  },
  text: {
    color: '#FFFFFF'
  },
  verdinha : {
    color: '#518F79',
    fontFamily: 'SawarabiGothic-Regular',
  },
  areaServ : {
    width : '100%',
    height : 500,
    alignItems : 'center',
    justifyContent : 'space-evenly'
  },
  serv :{
    height : 400,
    justifyContent : 'space-between'
  },
  sera : {
    width : '80%',
    color: '#518F79',
    fontFamily: 'SawarabiGothic-Regular',
    textAlign : 'center'
  }
});

export default App;
