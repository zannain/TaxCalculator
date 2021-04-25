export class ZipCodeViewModel {
    "post code": string
    "country": string
    "country abbreviation": string
    "places": [PlacesViewModel]

}

export class PlacesViewModel {
    "place name" : string
    "longitude": string
    "state abbreviation": string
    "latitude": string
}