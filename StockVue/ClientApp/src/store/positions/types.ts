export interface Position {
    name: string;
    ticker: string;
    numberOfShares: number;
    currentPrice: number;
    avgPrice: number;
    marketValue: number;
    gainValue: number;
    gainPct: number;
}

export interface PositionsState {
    positions: Position[];
}
