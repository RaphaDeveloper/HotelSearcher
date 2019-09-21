import { Component } from '@angular/core';
import { HotelRepository } from '../hotel.repository';
import { Hotel } from '../hotel';

@Component({
    selector: "hotel-searcher",
    templateUrl: "hotel.searcher.component.html"
})
export class HotelSearcherComponent {
    constructor(private hotelRepository: HotelRepository) { }

    get hotels(): Hotel[] {
        return this.hotelRepository.getHotels();
    }
}