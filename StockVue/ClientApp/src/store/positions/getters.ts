import { GetterTree } from 'vuex';
import { PositionsState } from './types';
import { RootState } from '../types';

export const getters: GetterTree<PositionsState, RootState> = {
    positionCount(state): number {
        return state.positions.length;
    },
    getAll(state): any {
        return state.positions;
    },
};
