import { MutationTree } from 'vuex';
import { PositionsState,Position } from './types';

export const mutations: MutationTree<PositionsState> = {
    addPosition(state, position: Position) {
        console.log('Entered Mutation -- addPosition');
        state.positions.push(position);
  },
    removePosition(state, positionTicker: string) {
        console.log('Entered Mutation -- removePosition');
        state.positions = state.positions.filter(p => p.ticker !== positionTicker);
    },
    loadStockPositions(state, positionsData) {        
        //TODO: Dummy data. replace this with the actual data
        console.log('Entered Mutation -- loadStockPositions');
        state.positions = [
            { ticker: 'T', name: 'AT&T', numberOfShares: 100, currentPrice: 29.85, AvgPrice: 25.52 },
            { ticker: 'INTC', name: 'Intel', numberOfShares: 200, currentPrice: 41.12, AvgPrice: 43.54 },
        ];
    },
};
