import React from 'react';
import {View, Text, StyleSheet} from 'react-native'
import Header1 from './components/Header'

const App = () => {
    return (
        <View style={styles.container}>
            <Header1/>
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
      
     }
})

export default App;