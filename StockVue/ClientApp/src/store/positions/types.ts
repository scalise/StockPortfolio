export interface Position {
    name: string;
    ticker: string;
    numberOfShares: number;
    currentPrice: number;
    AvgPrice: number;
}

export interface PositionsState {
    positions: Position[];
}
