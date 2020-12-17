import { MutationTree } from 'vuex';
import { RootState } from './types';
import { SummaryData } from './types';


export const mutations: MutationTree<RootState> = {
    loadSummaryData(state, summaryData) {
        
        let parsedSummaryData: SummaryData = {
            balance: summaryData.balance,
            totalCash: summaryData.totalCash,
            totalPositions: summaryData.positions,
            todaysNetChangeValue: summaryData.todaysNetChangeValue,
            todaysNetChangePercent: summaryData.todaysNetChangePercent
        };
            
        state.summary = parsedSummaryData;                  
    },
    
};
