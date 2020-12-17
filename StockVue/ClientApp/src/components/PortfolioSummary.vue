<template>
    <v-row>
        <v-col lg="12" md="12">
            <v-card>
                <v-list>
                    <v-list-item>
                        <v-list-item-content>
                            <v-list-item-title>Total Cash</v-list-item-title>
                        </v-list-item-content>
                        <v-list-item-action>
                            <v-list-item-title v-if="item" v-html="`<span>$</span>${item.totalCash}`"></v-list-item-title>
                        </v-list-item-action>
                    </v-list-item>

                    <v-list-item>
                        <v-list-item-content>
                            <v-list-item-title>Total Positions</v-list-item-title>
                        </v-list-item-content>
                        <v-list-item-action>
                            <v-list-item-title v-if="item" v-html="`<span>$</span>${item.totalPositions}`"></v-list-item-title>
                        </v-list-item-action>
                    </v-list-item>


                </v-list>
            </v-card>
        </v-col>
    </v-row>
</template>
<script>

    export default {
        name: 'PortfolioSummary',        
        computed: {
            item() {                                
                if (isNaN(this.$store.state.summary.balance))
                    return null;

                return this.$store.state.summary;
            }
        },        
    };
</script>