import { GameType } from "./_models/game-type";

export class AppSettings {
    public static API_ENDPOINT = 'http://localhost:58028/';
    public static LEAGUES = ['A', 'B'];
    public static DEFAULT_LEAGUE = AppSettings.LEAGUES[0];
    public static GAME_TYPES: GameType[] = [
            new GameType ('regular_season_game', 0),
            new GameType ('playoff_game', 1),
            new GameType ('exibition_game', 2)
        ];
    public static DEFAULT_GAME_TYPE = AppSettings.GAME_TYPES[0].value;
}
