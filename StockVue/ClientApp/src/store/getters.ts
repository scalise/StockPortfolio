import { GetterTree } from 'vuex';
import { RootState } from './types';

export const getters: GetterTree<RootState, RootState> = {
    historyData(state): object[] {
        return state.history.data;
    },
    historyLabels(state): string[] {
        return state.history.labels;
    },
};
