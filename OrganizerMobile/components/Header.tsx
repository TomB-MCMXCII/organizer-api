import React from 'react';
import {View, Text, StyleSheet, Alert} from 'react-native'
import {Header,Icon} from 'react-native-elements'
import LinearGradient from 'react-native-linear-gradient';

const Header1 = () => {
    return (
        <View>
            <Header
            placement="center"
            leftComponent={{ icon: 'home', color: '#fff', size: 35, onPress: () => Alert.alert('ea'), }}
            centerComponent={{ text: 'Today', style: { color: '#fff', fontSize:25 } }}
            rightComponent={{ icon: 'refresh', color: '#fff', size: 35 }}
            containerStyle={{
                backgroundColor: '#3D6DCC',
                justifyContent: 'space-around',
              }}
            />
        </View>
    );
};

const styles = StyleSheet.create({
   
})

export default Header1;