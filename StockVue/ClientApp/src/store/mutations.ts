import { MutationTree } from 'vuex';
import { RootState } from './types';
import { SummaryData } from './types';


export const mutations: MutationTree<RootState> = {
    loadSummaryData(state, summaryData) {
        const parsedSummaryData: SummaryData = {
            balance: summaryData.balance,
            totalCash: summaryData.totalCash,
            totalPositions: summaryData.positions,
            todaysNetChangeValue: summaryData.todaysNetChangeValue,
            todaysNetChangePercent: summaryData.todaysNetChangePercent,
        };
        state.summary = parsedSummaryData;
    },
    loadHistoryData(state, historyData) {
        state.history.data = historyData.balanceData.map((x: { balance: any; }) => x.balance);
        state.history.labels = historyData.balanceData.map((x: { balanceDate: any; }) => x.balanceDate);
    },
};
