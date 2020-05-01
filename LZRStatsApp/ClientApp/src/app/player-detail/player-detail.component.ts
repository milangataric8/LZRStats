import { Component, OnInit, Input } from '@angular/core';

import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html',
  styleUrls: ['./player-detail.component.css']
})
export class PlayerDetailComponent implements OnInit {
  private player: Player;

  constructor(private route: ActivatedRoute, private playersService: PlayersService) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const playerId: number = +params['id'];

      this.loadPlayer(playerId);
   });
  }

  private loadPlayer = (playerId: number) => {
    this.playersService
      .getBy(playerId)
      .subscribe(p => {
        this.player = p as Player;
      },
        (error) => {
          console.error(`Error happen while fetching player by ${playerId}`);
        });
  }
}
