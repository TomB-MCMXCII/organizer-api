import React, { Component } from 'react';
import { View, Text } from 'react-native';
import DaysList from './components/DaysList';
import AppHeader from './components/Header';

class App extends Component {
  
  render() {
    return (
      <View>
        <AppHeader/>
        <DaysList/>
      </View>
    )
  }
}

export default App;
