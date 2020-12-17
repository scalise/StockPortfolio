export interface SummaryData {
    totalCash: number;
    totalPositions: number;
    todaysNetChangeValue: number;
    todaysNetChangePercent: number;
    balance: number;
}

export interface HistoryData {
    data: object[];
    labels: string[];
}

export interface RootState {
    version: string;
    urlBase: string;
    summary: SummaryData;
    history: HistoryData;
}

