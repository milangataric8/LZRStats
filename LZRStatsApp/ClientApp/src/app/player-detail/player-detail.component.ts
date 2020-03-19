import { Component, OnInit } from '@angular/core';

import { PlayersService } from '../_services/players.service';
import { Player } from '../_models/player';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html',
  styleUrls: ['./player-detail.component.css']
})
export class PlayerDetailComponent implements OnInit {

    player: Player;
    private playerId: Number;

    constructor(private route: ActivatedRoute, private PlayersService: PlayersService){
      
      route.params.subscribe(param => {
        this.playerId = param['id'];
      });
    }

    ngOnInit() {
      if (this.playerId) {
        this.loadPlayer();
      }
    }
    
    private loadPlayer = () => {
      this.PlayersService
        .getBy(this.playerId)
        .subscribe(p => {
          this.player = p as Player;
        },
        (error) => {
          console.error(`Error happen while fetching project by ${this.playerId}`);
        });
    }
}
