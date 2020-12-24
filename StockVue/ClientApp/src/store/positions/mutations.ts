import { MutationTree } from 'vuex';
import { PositionsState,Position } from './types';

export const mutations: MutationTree<PositionsState> = {
    addPosition(state, position: Position) {
        console.log('Entered Mutation -- addPosition');
        
        //TODO - when updating an existing ticker add to that position instead of adding a new one.
        let pos = state.positions.find(x => x.ticker === position.ticker);
        if (pos === undefined) {
            // brand new position that didn't already exist, add it.
            state.positions.push(position);
        }
        else {
            // update existing items position data with newly added position details
            pos.avgPrice = position.avgPrice;
            pos.currentPrice = position.currentPrice;
            pos.gainPct = position.gainPct;
            pos.gainValue = position.gainValue;
            pos.marketValue = position.marketValue;            
            pos.numberOfShares = position.numberOfShares;            
        }
  },
    removePosition(state, positionTicker: string) {
        console.log('Entered Mutation -- removePosition');
        state.positions = state.positions.filter(p => p.ticker !== positionTicker);
    },
    loadStockPositions(state, positionsData) {        
        //TODO: Dummy data. replace this with the actual data
        console.log('Entered Mutation -- loadStockPositions');
        state.positions = [
            { ticker: 'T', name: 'AT&T', numberOfShares: 100, currentPrice: 29.85, avgPrice: 25.52, marketValue: 1000.00, gainValue: -120.00, gainPct: -1.20 },
            { ticker: 'INTC', name: 'Intel', numberOfShares: 200, currentPrice: 41.12, avgPrice: 43.54, marketValue: 1000.00, gainValue: 0.00, gainPct: 0.00 },
            { ticker: 'MSFT', name: 'Microsoft', numberOfShares: 100, currentPrice: 212.34, avgPrice: 157.54, marketValue: 10000.00, gainValue: 200.10, gainPct: 1.20 },
        ];
    },
};
