<template>
    <v-layout>        
        <v-row>
            <v-col lg="12" md="12">
                <v-data-table :headers="headers"
                              :items="items"
                              :items-per-page="10"
                              class="elevation-1">
                    <template v-slot:item.gainValue="{ item }">
                        <v-chip :color="getColor(item.gainValue)" dark>{{ item.gainValue }}</v-chip>
                    </template>
                </v-data-table>
            </v-col>
        </v-row>
    </v-layout>
</template>
<script>
    import { Position } from '@/store/positions/types';

    export default {
        name: 'StockPositions',
        props: {
            items: {
                type: Array
            }
        },
        data() {
            return {
                headers: [
                    { text: 'Name', align: 'start', sortable: false, value: 'name', },
                    { text: 'Symbol', value: 'ticker' },
                    { text: 'Shares', value: 'numberOfShares' },
                    { text: 'Price', value: 'currentPrice' },
                    { text: 'Avg Price', value: 'avgPrice' },
                    { text: 'Market Value', value: 'marketValue' },
                    { text: 'Gain ($)', value: 'gainValue' },
                    { text: 'Gain (%)', value: 'gainPct' },
                ],
            }
        },
        methods: {
            getColor(gainValue) {
                if (gainValue < 0) return 'red'
                else if (gainValue > 0) return 'green'
                else return 'black'
            },
        },
    };
</script>