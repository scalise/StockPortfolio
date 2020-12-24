<template>
    <v-layout>        
        <v-row>
            <v-col lg="12" md="12">
                <v-data-table :headers="headers"
                              :items="items"
                              :items-per-page="10"
                              class="elevation-1">
                    <!--
                        
                        EXAMPLE: customizing grid (color for gain) for single column
                        
                        <template v-slot:item.gainValue="{ item }">
                        <v-chip :color="getColor(item.gainValue)" dark>{{ item.gainValue }}</v-chip>
                    </template>-->

                    <!-- EXAMPLE: overriding defaulty table template with custom rendering -->
                    <template slot="items" slot-scope="props">
                        <td>{{ props.item.name }}</td>
                        <td>{{ props.item.ticker }}</td>
                        <td>{{ props.item.numberOfShares }}</td>
                        <td>{{ props.item.currentPrice }}</td>
                        <td>{{ props.item.avgPrice }}</td>
                        <td>{{ props.item.marketValue }}</td>
                        <td>{{ props.item.gainValue }}</td>                        
                        <td>{{ props.item.gainPct }}</td>
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
                console.log('x');
                if (gainValue < 0) return 'red'
                else if (gainValue > 0) return 'green'
                else return 'black'
            },
        },
    };
</script>