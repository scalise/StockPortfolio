export interface SummaryData {
    totalCash: number;
    totalPositions: number;
    todaysNetChangeValue: number;
    todaysNetChangePercent: number;
    balance: number;
}

export interface RootState {
    version: string;
    urlBase: string;
    summary: SummaryData;
}

