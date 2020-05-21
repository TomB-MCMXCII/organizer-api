import React, { Component, Props } from "react";
import httpRequestService from '../services/httpRequestService'
import { Text, View, FlatList} from "react-native";
import Day from '../models/Day'
import DaysListItem from '../components/DaysListItem'

class Dayslist extends Component {
    constructor(props) {  
        super(props);  
        this.state = {  
            Days:[],
            content: "yo",
        };  
    }  
    componentDidMount = () => {
        var request:httpRequestService = new httpRequestService();
         request.getDays()
         .then((response) => response.json())
          .then((responseJson) => {
           this.setState({Days: responseJson});
          })
          .catch((error) => {
            console.error(error);
          });

      }
      render(){
          return(
            <View>
                <FlatList
                data={this.state.Days}
                renderItem={({ item }) => <DaysListItem item={item} />}
                />
            </View>
          )
      }
}

export default Dayslist;