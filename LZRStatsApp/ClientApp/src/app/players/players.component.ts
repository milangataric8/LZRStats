import { Component, OnInit } from '@angular/core';
import { PlayersService } from '../_services/players.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  constructor(private playersService: PlayersService) { }

  ngOnInit() {
    this.playersService.getAll().subscribe(x => console.log(x));
  }

}
