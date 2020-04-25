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

  private playerId: Number;

  constructor(private route: ActivatedRoute, private playersService: PlayersService) {

  }

  ngOnInit() {
    this.route
      .queryParams
      .subscribe(params => {
        // Defaults to 0 if no query param provided.
        this.player = params['player'] || new Player();
      });
  }

  private loadPlayer = () => {
    this.playersService
      .getBy(this.playerId)
      .subscribe(p => {
        this.player = p as Player;
      },
        (error) => {
          console.error(`Error happen while fetching project by ${this.playerId}`);
        });
  }
}
