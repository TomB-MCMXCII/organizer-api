import rnFetchBlob from './selfSignedHttpClient'

export default class httpRequestService {
    getDays(){
        return rnFetchBlob.fetch('GET',' https://localhost:44392/api/day/getDays');
    }
}